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

            var modules = await _mediatR.Send(query);

            return Ok(modules);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetModuleByIdQuery(id);

                var module = await _mediatR.Send(query);

                return Ok(module);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateModuleCommand command)
        {
            try
            {
                var id = await _mediatR.Send(command);

                return CreatedAtAction(nameof(GetById), new { id }, command);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put(int id, UpdateModuleCommand command)
        {
            try
            {
                command.Id = id;

                await _mediatR.Send(command);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteModuleCommand(id);

                await _mediatR.Send(command);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
