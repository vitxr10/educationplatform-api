using EducationPlatform.Application.Commands.UserCommands;
using EducationPlatform.Application.Commands.VideoLessonCommands;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Application.Queries.UserQueries;
using EducationPlatform.Application.Queries.VideoLessonQueries;
using EducationPlatform.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EducationPlatform.API.Controllers
{
    [Route("api/videolessons")]
    [ApiController]
    public class VideoLessonsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public VideoLessonsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllVideoLessonsQuery();

            var videoLessons = await _mediatR.Send(query);

            return Ok(videoLessons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetVideoLessonByIdQuery(id);

                var user = await _mediatR.Send(query);

                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Post(CreateLessonCommand command)
        {
            var id = await _mediatR.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateVideoLessonCommand command)
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteVideoLessonCommand(id);

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
