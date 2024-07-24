using EducationPlatform.Application.Commands.ModuleCommands;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Application.Queries.ModuleQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.API.Controllers
{
    [Route("api/modules")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public ModulesController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("course/{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetByCourseId(int id)
        {
            var query = new GetModulesByCourseIdQuery(id);

            var result = await _mediatR.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetModuleByIdQuery(id);

            var result = await _mediatR.Send(query);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateModuleCommand command)
        {
            var result = await _mediatR.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put(int id, UpdateModuleCommand command)
        {
            command.Id = id;

            var result = await _mediatR.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteModuleCommand(id);

            var result = await _mediatR.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return NoContent();
        }
    }
}
