using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Repository
{
    public interface IEngineRepository
    {
        void Create(Engine car);
        Engine ReadOne(int id);
        IQueryable<Engine> ReadAll();
        void Update(Engine car);
        void Delete(int engineId);
    }
}
