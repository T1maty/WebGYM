using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Actual;
using WebGYM.Application.CQRS.Commands.Actual.UpdateActual;
using WebGYM.Application.Gym.Commands.User.UpdateUser;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ActualController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public ActualController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("actual-subscription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualSubscription([FromBody] UpdateActualModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var command = _mapper.Map<UpdateActualCommand>(model);

            return Ok();
        }
    }
}
