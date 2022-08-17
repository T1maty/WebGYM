using ProductWebGYM.Data;
using ProductWebGYM.Models;
using ProductWebGYM.Services.Interfaces;

namespace ProductWebGYM.Services
{
    public class AbonementService : IAbonementService
    {
        private readonly DbContextClass _dbContext;
        public AbonementService(DbContextClass dataContext)
        {
            _dbContext = dataContext;
        }

        public Abonement AddAbonement(Abonement product)
        {
            var result  = _dbContext.Abonements.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Result DeleteAbonement(int id)
        {
            try
            {
                if (id==null)
                {
                    return new Result
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ErrorMessage = "Id was not provided"
                    };
                }
                var filteredData = _dbContext.Abonements.Where(x => x.Id == id).FirstOrDefault();
                if (filteredData ==null)
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
                    Id = result.Entity.Id,
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

        public Abonement UpdateAbonement(Abonement product)
        {
            var result = _dbContext.Abonements.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;

        }
    }
}
