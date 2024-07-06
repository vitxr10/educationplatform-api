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
        [Authorize (Roles = "Administrator")]
        public async Task<IActionResult> GetAll(string? StringQuery)
        {
            var query = new GetAllCoursesQuery(StringQuery);

            var courses = await _mediatR.Send(query);

            return Ok(courses);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetCourseByIdQuery(id);

                var course = await _mediatR.Send(query);

                return Ok(course);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateCourseCommand command)
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
        public async Task<IActionResult> Put(int id, UpdateCourseCommand command)
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
                var command = new DeleteCourseCommand(id);

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
