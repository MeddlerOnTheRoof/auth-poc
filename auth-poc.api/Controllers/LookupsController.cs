using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using auth_poc.data.Interfaces;
using auth_poc.data.Models;
using Swashbuckle.SwaggerGen.Annotations;

namespace auth_poc.api.Controllers
{
    [Route("api/[controller]")]
    public class LookupsController : Controller
    {
        private readonly ILookupsRepository _db;

        public LookupsController(ILookupsRepository db)
        {
            _db = db;
        }

        [HttpGet("UnitTypes")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<UnitType>))]
        public async Task<IActionResult> Get()
        {
            var unitTypes = await _db.GetUnitTypes();

            return Ok(unitTypes);
        }
    }
}
