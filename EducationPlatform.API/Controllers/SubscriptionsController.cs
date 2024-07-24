using EducationPlatform.Application.Commands.SubscriptionCommands;
using EducationPlatform.Application.Queries.SubscriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.API.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public SubscriptionsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetAll(string? StringQuery)
        {
            var query = new GetAllSubscriptionsQuery(StringQuery);

            var result = await _mediatR.Send(query);

            return Ok(result);
        }

        [HttpGet("users/{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetAllByUserId(int id)
        {
            var query = new GetAllSubscriptionsByUserIdQuery(id);

            var result = await _mediatR.Send(query);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Student")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSubscriptionByIdQuery(id);

            var result = await _mediatR.Send(query);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateSubscriptionCommand command)
        {
            var result = await _mediatR.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put(int id, UpdateSubscriptionCommand command)
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
            var command = new DeleteSubscriptionCommand(id);

            var result = await _mediatR.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return NoContent();
        }
    }
}
