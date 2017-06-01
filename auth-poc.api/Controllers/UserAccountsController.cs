using System.Collections.Generic;
using System.Threading.Tasks;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.AspNetCore.Mvc;
using auth_poc.data.Models;
using auth_poc.data.Interfaces;

namespace auth_poc.api.Controllers
{
    [Route("api/[controller]")]
    public class UserAccountsController : Controller
    {
        private readonly IUserAccountsRepository _db;
        
        public UserAccountsController(IUserAccountsRepository db)
        {
            _db = db;
        }

        [HttpGet]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<UserAccount>))]
        public async Task<IActionResult> Get()
        {
            var userAccounts = await _db.GetUserAccountsAsync();

            return Ok(userAccounts);
        }

        [HttpGet("{userAccountId}")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(UserAccount))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int userAccountId)
        {
            var userAccount = await _db.GetUserAccountAsync(userAccountId);

            if (userAccount == null)
                return NotFound();

            return Ok(userAccount);
        }

        [HttpPost]
        [SwaggerResponse(System.Net.HttpStatusCode.Created)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]UserAccount userAccount)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            var id = await _db.AddUserAccountAsync(userAccount);

            return CreatedAtAction(nameof(Get), new { userAccountId = id }, userAccount);
        }

        [HttpPut("{userAccountId}")]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int userAccountId, [FromBody]UserAccount userAccount)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            if (!await _db.IsExistingUserAccountAsync(userAccountId))
                return new NotFoundResult();

            await _db.UpdateUserAccountAsync(userAccount);

            return new NoContentResult();
        }

        [HttpDelete("{userAccountId}")]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int userAccountId)
        {
            if (!await _db.IsExistingUserAccountAsync(userAccountId))
                return new NotFoundResult();

            await _db.DeleteUserAccountAsync(userAccountId);

            return new NoContentResult();
        }
    }
}
