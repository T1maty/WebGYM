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

        public Abonement UpdateAbonement(Abonement product)
        {
            var result = _dbContext.Abonements.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
