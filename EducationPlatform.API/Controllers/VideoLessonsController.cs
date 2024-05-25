using EducationPlatform.Application.Commands.VideoLessonCommands;
using EducationPlatform.Application.Queries.VideoLessonQueries;
using EducationPlatform.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllVideoLessonsQuery();

            var videoLessons = await _mediatR.Send(query);

            return Ok(videoLessons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            return Ok();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Post(CreateLessonCommand command)
        {
            var id = await _mediatR.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
