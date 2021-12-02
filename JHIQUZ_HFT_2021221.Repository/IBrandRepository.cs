using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Repository
{
    public interface IBrandRepository
    {
        void Create(Brand brand);
        Brand ReadOne(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand brand);
        void Delete(int brandId);
    }
}
