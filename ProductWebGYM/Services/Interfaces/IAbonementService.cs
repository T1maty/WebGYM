using ProductWebGYM.Models;
using WebGYM.Shared.Models;

namespace ProductWebGYM.Services.Interfaces
{
    public interface IAbonementService
    {
        public Abonement AddAbonement(Abonement product);
        public Abonement UpdateAbonement(Abonement product);
        public Result DeleteAbonement(int? id);
    }
}
