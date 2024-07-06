using EducationPlatform.Application.Commands.SubscriptionCommands;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Application.Queries.SubscriptionQueries;
using EducationPlatform.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAll(string? StringQuery)
        {
            var query = new GetAllSubscriptionsQuery(StringQuery);

            var subscriptions = await _mediatR.Send(query);

            return Ok(subscriptions);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetAllByUserId(int id)
        {
            var query = new GetAllSubscriptionsByUserIdQuery(id);

            var subscriptions = await _mediatR.Send(query);

            return Ok(subscriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetSubscriptionByIdQuery(id);

                var subscription = await _mediatR.Send(query);

                return Ok(subscription);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSubscriptionCommand command)
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
        public async Task<IActionResult> Put(int id, UpdateSubscriptionCommand command)
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
                var command = new DeleteSubscriptionCommand(id);

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
