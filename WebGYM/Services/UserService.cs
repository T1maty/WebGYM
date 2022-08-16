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

        public bool DeleteUser(int id)
        {
            var filteredData = _dbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();

            return result != null ? true : false;

            if (filteredData == null)
            {
                return NotFound();
            }
            

        }

        private bool NotFound()
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User product)
        {
            var result = _dbContext.Users.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
