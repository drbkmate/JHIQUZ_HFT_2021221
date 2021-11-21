using JHIQUZ_HFT_2021221.Models;
using JHIQUZ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Logic
{
    public class EngineLogic : IEngineLogic
    {
        IEngineRepository repo;

        public EngineLogic(IEngineRepository repo)
        {
            this.repo = repo;
        }

        public double AverageCcm()
        {
            return repo
                .ReadAll()
                .Average(x => x.Ccm);
        }

        public void Create(Engine engine)
        {
            repo.Create(engine);
        }

        public void Delete(int engineId)
        {
            repo.Delete(engineId);
        }

        public IQueryable<Engine> ReadAll()
        {
            return repo.ReadAll();
        }

        public Engine ReadOne(int id)
        {
            return repo.ReadOne(id);
        }

        public void Update(Engine engine)
        {
            repo.Update(engine);
        }
    }
}
