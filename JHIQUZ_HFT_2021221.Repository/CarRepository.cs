using JHIQUZ_HFT_2021221.Data;
using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Repository
{
    public class CarRepository : ICarRepository
    {
        CarShopContext context;

        public CarRepository(CarShopContext context)
        {
            this.context = context;
        }

        public void Create(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void Delete(int carId)
        {
            context.Cars.Remove(ReadOne(carId));
            context.SaveChanges();
        }

        public IQueryable<Car> ReadAll()
        {
            return context.Cars;
        }

        public Car ReadOne(int id)
        {
            return context
                .Cars
                .FirstOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car old = ReadOne(car.Id);

            old.Model = car.Model;
            old.BasePrice = car.BasePrice;
            old.BrandId = car.BrandId;
            old.EngineId = car.EngineId;
            
            context.SaveChanges();
        }
    }
}
