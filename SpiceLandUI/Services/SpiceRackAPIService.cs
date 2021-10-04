using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SpiceLandPOCOs;
using SpiceLandUI.Models;

namespace SpiceLandUI.Services
{
    public class SpiceLandApiService : BaseService
    {
        public SpiceLandApiService(IHttpClientFactory clientFactory,
            IOptions<AppSettings> appSettings) : base(
            clientFactory, appSettings)
        {
        }

        public async Task DeleteSpice(int id)
        {
            using var response =
                await _clientFactory.CreateClient().DeleteAsync($"{_baseUrl}spice/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Spice> UpdateSpice(Spice spice)
        {
            using var response = await _clientFactory.CreateClient().PutAsJsonAsync($"{_baseUrl}spice", spice);
            response.EnsureSuccessStatusCode();


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Spice>();

                if (data != null)
                {
                    return data;
                }
            }

            return null;
        }

        public async Task<Spice> CreateSpice(Spice spice)
        {
            using var response =
                await _clientFactory.CreateClient().PostAsJsonAsync($"{_baseUrl}spice", spice);
            response.EnsureSuccessStatusCode();


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Spice>();

                if (data != null)
                {
                    return data;
                }
            }

            return null;
        }

        public async Task<Spice> GetSpice(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_baseUrl}spice");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<Spice>>();

                if (data != null && data.ToList().Any(x => x.Id == id))
                {
                    return data.ToList().FirstOrDefault(x => x.Id == id);
                }
            }

            return null;
        }

        public async Task<List<Spice>> GetSpices()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_baseUrl}spice");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<Spice>>();

                if (data != null)
                {
                    return data.ToList();
                }
            }

            return null;
        }
    }
}