using EducationPlatform.Application.Commands.CourseCommands;
using EducationPlatform.Application.Queries.CourseQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.API.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public CoursesController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAll(string? StringQuery)
        {
            var query = new GetAllCoursesQuery(StringQuery);

            var result = await _mediatR.Send(query);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCourseByIdQuery(id);

            var result = await _mediatR.Send(query);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateCourseCommand command)
        {
            var result = await _mediatR.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put(int id, UpdateCourseCommand command)
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
            var command = new DeleteCourseCommand(id);

            var result = await _mediatR.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return NoContent();
        }

        [HttpPost("generatecertificate")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GenerateCertificate(GenerateCourseCertificateCommand command)
        {
            var result = await _mediatR.Send(command);

            return NoContent();
        }
    }
}
