using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleManagement.Context;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SaleManagement.Controllers
{
    [Route("sales")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SaleContext _db;

        public ValuesController(SaleContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _db.Customers
                                .Include(c => c.CustomerDetail)
                                .Include(p=>p.Products)
                                .ToList();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(customers, options);
            return Content(json, "application/json");
        }
    }
}
