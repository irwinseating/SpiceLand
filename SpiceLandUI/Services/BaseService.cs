using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Options;
using SpiceLandUI.Models;

namespace SpiceLandUI.Services
{
    public class BaseService
    {
        internal readonly IHttpClientFactory _clientFactory;
        internal readonly string _baseUrl;
        internal readonly JsonSerializerOptions _jsonOptions;

        public BaseService(IHttpClientFactory clientFactory, IOptions<AppSettings> appSettings)
        {
            _clientFactory = clientFactory;
            _baseUrl = appSettings.Value.WebApiUrl;
            _jsonOptions = new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true };
        }
    }
}