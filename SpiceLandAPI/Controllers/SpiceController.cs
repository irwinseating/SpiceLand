using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpiceLandApi.DataAccess;
using SpiceLandPOCOs;

namespace SpiceLandApi.Controllers
{
    [Route("Spice")]
    [ApiController]
    public class SpiceController : ControllerBase
    {
        private readonly DatabaseContext _dbcontext;

        public SpiceController()
        {
            var connectionString = GetConnectionString();

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(connectionString)
                .Options;
            _dbcontext = new DatabaseContext(options);

            _dbcontext.Database.EnsureCreated();
        }

        private IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        private string GetConnectionString()
        {
            return GetConfiguration().GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dbSpices = _dbcontext.Set<Spice>();

            return Ok(dbSpices.AsQueryable().ToList());
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Spice x)
        {
            var dbSpices = _dbcontext.Set<Spice>();

            dbSpices.Add(x);
            _dbcontext.SaveChanges();
            return Ok(x);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Spice x)
        {
            var dbSpices = _dbcontext.Set<Spice>();

            for (var i = 0; i < dbSpices.AsQueryable().ToList().Count(); i++)
            {
                if (dbSpices.AsQueryable().ToList()[i].Id == x.Id)
                {
                    var spice = dbSpices.AsQueryable().ToList()[i];
                    spice.Name = x.Name;
                    spice.ExpirationDate = x.ExpirationDate;
                    spice.LastUsedDate = x.LastUsedDate;
                    spice.PurchaseDate = x.LastUsedDate;

                    dbSpices.Update(spice);
                }
            }

            _dbcontext.SaveChanges();


            return Ok(x);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _dbcontext.Set<Spice>().Remove(new Spice() { Id = id });

            _dbcontext.SaveChanges();
            return Ok(new
            {
                success = "true"
            });
        }
    }
}