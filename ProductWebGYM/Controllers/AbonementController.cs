using Microsoft.AspNetCore.Mvc;
using ProductWebGYM.Models;
using WebGYM.Shared.Services;

namespace ProductWebGYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonementController : ControllerBase
    {
        private readonly IGenericService _service;
        private readonly ILogger<AbonementController> _logger;

        
        public AbonementController(IGenericService service,ILogger<AbonementController>logger)
        {
            _service = service;
            _logger = logger;
        }
        

        /// <summary>
        /// Gets the Abonement by id
        /// </summary>
        /// <param name="id">Abonement Id</param>
        /// <returns>Result of retrieving</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get(int? id)
        {
            var result = _service.Get<Abonement>(id);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Creates the Abonement
        /// </summary>
        /// <param name="user">Abonement entity</param>
        /// <returns>Result of creation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Create(Abonement user)
        {
            _logger.LogInformation("Product excuting...");
            var result = _service.Create(user);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Updates the Abonement
        /// </summary>
        /// <param name="user">Abonement entity</param>
        /// <returns>Result of updating</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateUser(Abonement user)
        {
            var result = _service.Update(user);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Deletes Abonement by specified id
        /// </summary>
        /// <param name="id">Abonement id</param>
        /// <returns>Result of deletion</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int? id)
        {
            var result = _service.Delete<Abonement>(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
