using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGYM.Models;
using WebGYM.Services.Interfaces;

namespace WebGYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpPost]
        public User AddUser(User user)
        {
            return userService.AddUser(user);
        }
        [HttpPut]
        public User UpdateUser(User user)
        {
            return userService.UpdateUser(user);
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
            var result = userService.DeleteUser(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
