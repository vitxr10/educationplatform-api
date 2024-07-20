using EducationPlatform.Application.Commands.VideoLessonCommands;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Application.Queries.VideoLessonQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllVideoLessonsQuery();

            var videoLessons = await _mediatR.Send(query);

            return Ok(videoLessons);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Student")]
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateVideoLessonCommand command)
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
            catch (Exception ex)
            {
                return BadRequest("Não foi possível cadastrar a videoaula.");
            }
        }

        [HttpPost("{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> Finish(int id, FinishVideoLessonCommand command)
        {
            command.VideoLessonId = id;

            var result = await _mediatR.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
