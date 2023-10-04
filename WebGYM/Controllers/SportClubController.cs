using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.SportClub;
using WebAPI.Service;
using WebGYM.Application.CQRS.Commands.SportClub.CreateSportClub;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportClubController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly MongoDBService _db;

        public SportClubController(IMediator mediator, IMapper mapper, MongoDBService mongoDBService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _db = mongoDBService; 
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
