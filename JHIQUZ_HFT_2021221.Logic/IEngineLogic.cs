using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Logic
{
    public interface IEngineLogic
    {
        double AverageCcm();

        void Create(Engine engine);
        Engine ReadOne(int id);
        IQueryable<Engine> ReadAll();
        void Update(Engine engine);
        void Delete(int engineId);
    }
}
