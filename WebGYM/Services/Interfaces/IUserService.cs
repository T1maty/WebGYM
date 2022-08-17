using WebGYM.Models;
using WebGYM.Shared.Models;

namespace WebGYM.Services.Interfaces
{
    public interface IUserService
    {
        public User AddUser(User product);
        public User UpdateUser(User product);
        public Result DeleteUser(int? id); 
    }
}
