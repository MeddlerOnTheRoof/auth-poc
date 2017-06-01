using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using auth_poc.data.Models;
using auth_poc.data.Interfaces;

namespace auth_poc.api.Controllers
{
    [Route("api/[controller]")]
    public class UnitsController : Controller
    {
        private readonly IUnitsRepository _db;

        public UnitsController(IUnitsRepository db)
        {
            _db = db;
        }

        [HttpGet]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<Unit>))]
        public async Task<IActionResult> Get()
        {
            var units = await _db.GetUnitsAsync();

            return Ok(units);
        }

        [HttpGet("{unitId}")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Unit))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int unitId)
        {
            var unit = await _db.GetUnitAsync(unitId);

            if (unit == null)
                return NotFound();

            return Ok(unit);
        }

        [HttpPost]
        [SwaggerResponse(System.Net.HttpStatusCode.Created)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]Unit unit)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            var id = await _db.AddUnitAsync(unit);

            return CreatedAtAction(nameof(Get), new { unitId = id }, unit);
        }

        [HttpPut("{unitId}")]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int unitId, [FromBody]Unit unit)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            if (!await _db.IsExistingUnitAsync(unitId))
                return new NotFoundResult();

            await _db.UpdateUnitAsync(unit);

            return new NoContentResult();
        }

        [HttpDelete("{unitId}")]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int unitId)
        {
            if (!await _db.IsExistingUnitAsync(unitId))
                return new NotFoundResult();

            await _db.DeleteUnitAsync(unitId);

            return new NoContentResult();
        }
    }
}
