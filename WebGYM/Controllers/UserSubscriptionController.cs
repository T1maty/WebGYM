using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.User;
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

        public UserSubscriptionController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
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
    }
}
