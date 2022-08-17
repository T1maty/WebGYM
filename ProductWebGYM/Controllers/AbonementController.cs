using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebGYM.Models;
using ProductWebGYM.Services.Interfaces;

namespace ProductWebGYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonementController : ControllerBase
    {
        private readonly IAbonementService _abonementService;
        public AbonementController(IAbonementService abonementService)
        {
            _abonementService = abonementService;
        }
        [HttpPost]
        public Abonement AddAbonement(Abonement abonement)
        {
            return _abonementService.AddAbonement(abonement);
        }
        [HttpPut]
        public Abonement UpdateAbonement(Abonement abonement)
        {
            return _abonementService.UpdateAbonement(abonement);
        }

        /// <summary>
        /// Deletes user by specified id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Result of deletion</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int? id)
        {
            var result = _abonementService.DeleteAbonement(id);
            return StatusCode((int)result.StatusCode, result);
        }

    }
}
