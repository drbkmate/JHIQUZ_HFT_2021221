using JHIQUZ_HFT_2021221.Logic;
using JHIQUZ_HFT_2021221.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarLogic logic;

        public CarController(ICarLogic logic)
        {
            this.logic = logic;
        }

        //OK
        // URL: /car
        [HttpGet]
        public IEnumerable<Car> ReadAllCars()
        {            
            return logic.ReadAll();
        }

        //NOK
        // URL: /car
        [HttpPost] 
        public void CreateCar(Car car)
        {  
            logic.Create(car);
        }

        //OK    
        //URL: /car/{carId}
        [HttpDelete("{carId}")]
        public void DeleteCar([FromRoute] int carId)
        {
            logic.Delete(carId);
        }

        //OK
        [HttpPut]
        public void UpdateCar([FromBody] Car car)
        {
            logic.Update(car);
        }
    }
}
