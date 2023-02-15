using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.SportClub;
using WebGYM.Application.CQRS.Commands.SportClub.CreateSportClub;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportClubController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SportClubController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("choice-of-sportclub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChoiceOfSportClub([FromBody] CreateSportClubModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var command = _mapper.Map<CreateSportClubCommand>(model);
            return Ok();

        }


    }
}
