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

        /// <summary>
        /// User registers for a subscription
        /// </summary>
        /// <remarks>
        /// Request example
        /// <code>
        /// POST /api/User
        /// {
        /// firstName: Nakamoto,
        /// lastName: Satoshi,
        ///  email: ftomi809@gmail.com,
        /// }
        /// </code>
        /// </remarks>
        /// 
        /// <param name="user">Sign Up for a gym membership </param>
        /// <returns>Nothing</returns>
        /// <response code="200">Successfully sign!</response>

        [HttpPost]
        public User AddUser(User user)
        {
            return userService.AddUser(user);
        }
        /// <summary>
        /// Update User Data
        /// Required fields are first name, last name and phone number
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public User UpdateUser(User user)
        {
            return userService.UpdateUser(user);
        }
        //test
        /// <summary>
        /// Deletes user by specified id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Result of deletion</returns>
        ///  /// <response code="200">Successfully Log out!</response>
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
