using Microsoft.EntityFrameworkCore;
using WebAPI.Service.Interfaces;
using WebGYM.Persistance;
using WebGYM.Shared.Models;

namespace WebAPI.Service
{
    public class SubscriptionService : ISubscriptionSevice
    {
        private readonly WebGymDbContext _dbContext;
        public Result DeleteSubscription(int id)
        {
            try
            {
                if (id == null)
                {
                    return new Result
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ErrorMessage = "Id not provided"
                    };
                }
                var filteredData = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
                if (filteredData == null)
                {
                    return new Result
                    {
                        Id = (int)id,
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        ErrorMessage = "Games id not found"
                    };
                }
                var result = _dbContext.Remove(filteredData);
                _dbContext.SaveChanges();

                return new Result
                {
                    Id = result.Entity.Id,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    CustomObject = result.Entity
                };

            }
            catch (Exception ex)
            {
                return new Result
                {
                    Id = (int)id,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
