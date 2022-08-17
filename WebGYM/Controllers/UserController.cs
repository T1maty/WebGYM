using Microsoft.AspNetCore.Mvc;
using WebGYM.Models;
using WebGYM.Shared.Services;

namespace WebGYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IGenericService _service;
        public UserController(IGenericService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets the user by id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Result of retrieving</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get(int? id)
        {
            var result = _service.Get<User>(id);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Creates the user
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>Result of creation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Create(User user)
        {
            var result = _service.Create(user);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>Result of updating</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateUser(User user)
        {
            var result = _service.Update(user);
            return StatusCode((int)result.StatusCode, result);
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
            var result = _service.Delete<User>(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
