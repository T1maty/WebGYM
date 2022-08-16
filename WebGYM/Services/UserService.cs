using Microsoft.AspNetCore.Mvc;
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

        public Result DeleteUser(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new Result
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ErrorMessage = "Id was not provided"
                    };
                }

                var filteredData = _dbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
                if (filteredData == null)
                {
                    return new Result
                    {
                        Id = id,
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        ErrorMessage = "User with specified Id was not found"
                    };
                }

                var result = _dbContext.Remove(filteredData);
                _dbContext.SaveChanges();

                return new Result
                {
                    Id = result.Entity?.Id,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    CustomObject = result.Entity
                };
            } 
            catch (Exception ex)
            {
                return new Result
                {
                    Id = id,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
            }
        }

        public User UpdateUser(User product)
        {
            var result = _dbContext.Users.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
