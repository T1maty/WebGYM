using WebGYM.Models;

namespace WebGYM.Services.Interfaces
{
    public interface IUserService
    {
        public User AddUser(User product);
        public User UpdateUser(User product);
        public User DeleteUser(int id); 
    }
}
