using System.ComponentModel.DataAnnotations;

namespace WebGYM.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }
        public string Username { get; internal set; }
        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; set; }
    }

}
