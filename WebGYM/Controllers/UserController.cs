using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGYM.Models;
using WebGYM.Services.Interfaces;

namespace WebGYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        

    }
}
