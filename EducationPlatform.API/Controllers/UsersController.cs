using EducationPlatform.Application.Commands.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public UsersController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public IActionResult GetAll(string? stringQuery)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var id = await _mediatR.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public IActionResult Put()
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}
