using WebGYM.Shared.Models;

namespace WebGYM.Models
{
    public class User : ServiceObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  string Email { get; set; }
    }
}
