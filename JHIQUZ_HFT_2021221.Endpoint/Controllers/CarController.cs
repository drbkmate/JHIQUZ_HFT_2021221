using JHIQUZ_HFT_2021221.Endpoint.Services;
using JHIQUZ_HFT_2021221.Logic;
using JHIQUZ_HFT_2021221.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub; 

        public CarController(ICarLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        // URL: /car
        [HttpGet]
        public IEnumerable<Car> ReadAllCars()
        {            
            return logic.ReadAll();
        }

        //URL: /car/{carId}
        [HttpGet("{carId}")]
        public Car ReadOneCar([FromRoute] int carId)
        {
            return logic.ReadOne(carId);
        }


        // URL: /car
        [HttpPost] 
        public void CreateCar(Car car)
        {  
            logic.Create(car);
            this.hub.Clients.All.SendAsync("CarCreated", car);
        }

  
        //URL: /car/{carId}
        [HttpDelete("{carId}")]
        public void DeleteCar([FromRoute] int carId)
        {
            var carToDelete = this.logic.ReadOne(carId);
            logic.Delete(carId);
            this.hub.Clients.All.SendAsync("CarDeleted", carToDelete);
        }


        [HttpPut]
        public void UpdateCar([FromBody] Car car)
        {
            logic.Update(car);
            this.hub.Clients.All.SendAsync("CarUpdated", car);
        }
    }
}
