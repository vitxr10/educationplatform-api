using EducationPlatform.Application.Commands.CourseCommands;
using EducationPlatform.Application.Commands.VideoLessonCommands;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Application.Queries.CourseQueries;
using EducationPlatform.Application.Queries.VideoLessonQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCourseByIdQuery(id);

            var result = await _mediatR.Send(query);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result);
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
    }
}
