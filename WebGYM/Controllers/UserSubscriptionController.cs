using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WebAPI.Models.User;
using WebAPI.Service.Interfaces;
using WebGYM.Application.Gym.Commands.User.CreateUser;
using WebGYM.Application.Gym.Commands.User.UpdateUser;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class UserSubscriptionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ISubscriptionSevice _subscriptionservice;
        private readonly IDistributedCache _cache;
        public UserSubscriptionController(IMapper mapper, IMediator mediator, ISubscriptionSevice subscriptionSevice, IDistributedCache cache)
        {
            _mapper = mapper;
            _mediator = mediator;
            _subscriptionservice = subscriptionSevice;
            _cache = cache;
        }

        [HttpPost("create-subscription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateSubscription([FromBody]  CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var command = _mapper.Map<CreateUserCommand>(model);
            //await _mediator.Send(command);

            return Ok();
        }

        [HttpGet ("update-subscription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSubscription([FromBody] UpdateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var command = _mapper.Map<UpdateUserCommand>(model);

            return Ok();
        }
        /// <summary>
        /// Deletes user by specified id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Result of deletion</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteSubscription(int id)
        {
            var result = _subscriptionservice.DeleteSubscription(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
