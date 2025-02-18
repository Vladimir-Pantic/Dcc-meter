
using DccMeter.Api.Domain;
using DccMeter.Api.Domain.Interfaces;
using DccMeter.Api.Domain.Models;
using Euronet.Audit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace DccMeterAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Audit]
    public class UsersController : ControllerBase
    {
        private const string SOURCE = "DccMeter.Api.Users";

        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetUserList([FromQuery]GetUserContext context)
        {
            //var list = await Task.Run(() => { return "Test user List"; });

            var list = await _repository.GetUserListAsync(context);

           return Ok(list);    
           
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var item = await _repository.GetUserAsync(id);

            if (item == null)
            {
                return this.NotFound($"User with identifier {id} not found!");  
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserCommand command)
        {
            var item = await _repository.RegisterUserAsync(command);

            if (item == null)
            {
                //return this.InternalServerError((int)ErrorCodes.TestProjectRegistrationFailed, $"Registration of the user failed due to internal server error.", SOURCE);
            }

            return Created($"{Request.Path}/{item.Idx}", item);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ModifyUserAsync([FromRoute]int id, [FromBody]ModifyUserCommand command)
        {
            if(await _repository.UserExistsAsync(id) == false)
            {
                return NotFound();
            }

            bool modified = await _repository.ModifyUserAsync(id, command);

            if (modified)
            {
                return NoContent();
            }
            else
            {
                return this.StatusCode(500);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUserAsync([FromRoute]int id)
        {
            if (await _repository.UserExistsAsync(id) == false)
            {
                return NotFound();
            }

            bool deleted = await _repository.RemoveUserAsync(id);

            if(deleted)
            {
                return NoContent();
            }
            else
            {
                return this.StatusCode(500);
            }


        }

    }
}