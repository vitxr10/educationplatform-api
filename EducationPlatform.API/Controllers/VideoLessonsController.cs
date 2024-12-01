using EducationPlatform.Application.Commands.VideoLessonCommands;
using EducationPlatform.Application.Common;
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

            var result = await _mediatR.Send(query);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetVideoLessonByIdQuery(id);

            var result = await _mediatR.Send(query);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("modules/{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetByModuleId(int id)
        {
            var query = new GetVideoLessonsByModuleIdQuery(id);

            var result = await _mediatR.Send(query);

            return Ok(result.Data);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateVideoLessonCommand command)
        {
            var result = await _mediatR.Send(command);

            if (result.ErrorTypeEnum == ErrorTypeEnum.NotFound)
                return NotFound(result.Message);

            if (result.ErrorTypeEnum == ErrorTypeEnum.Failure)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
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
            var command = new DeleteVideoLessonCommand(id);

            var result = await _mediatR.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return NoContent();
        }
    }
}
