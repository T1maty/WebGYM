using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebGYM.Models;
using ProductWebGYM.Services.Interfaces;

namespace ProductWebGYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonementController : ControllerBase
    {
        private readonly IAbonementService _abonementService;
        public AbonementController(IAbonementService abonementService)
        {
            _abonementService = abonementService;
        }
        [HttpPost]
        public Abonement AddAbonement(Abonement abonement)
        {
            return _abonementService.AddAbonement(abonement);
        }
        [HttpPut]
        public Abonement UpdateAbonement(Abonement abonement)
        {
            return _abonementService.UpdateAbonement(abonement);
        }
        
    }
}
