using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Repository
{
    public interface ICarShopModelRepository
    {
        void Create(IModel model);
        IModel ReadOne(int id); 
        IQueryable<IModel> ReadAll(); 
        void Update(IModel model);
        void Delete(int modelId);
    }
}
