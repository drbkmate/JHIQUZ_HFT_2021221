using JHIQUZ_HFT_2021221.Data;
using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Repository
{
    public class EngineRepository : IEngineRepository
    {
        CarShopContext context;

        public EngineRepository(CarShopContext context)
        {
            this.context = context;
        }

        public void Create(Engine engine)
        {
            context.Engines.Add(engine);
            context.SaveChanges();
        }

        public void Delete(int engineId)
        {
            context.Engines.Remove(ReadOne(engineId));
            context.SaveChanges();
        }

        public IQueryable<Engine> ReadAll()
        {
            return context.Engines;
        }

        public Engine ReadOne(int id)
        {
            return context
                .Engines
                .FirstOrDefault(e => e.Id == id);
        }

        public void Update(Engine engine)
        {
            Engine old = ReadOne(engine.Id);

            old.Ccm = engine.Ccm;
            old.Fuel = engine.Fuel;
            old.Car = engine.Car;
            old.CarId = engine.CarId;

            context.SaveChanges();
        }
    }
}
