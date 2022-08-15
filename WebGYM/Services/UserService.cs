using WebGYM.Data;
using WebGYM.Models;
using WebGYM.Services.Interfaces;

namespace WebGYM.Services
{
    public class UserService : IUserService
    {
        private readonly DbContextClass _dbContext;
        public UserService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public User AddUser(User product)
        {
            var result = _dbContext.Users.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public User DeleteUser(int id)
        {
            var filteredData = _dbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result.Entity;

        }

        

        public User UpdateUser(User product)
        {
            var result = _dbContext.Users.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
