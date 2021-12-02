using JHIQUZ_HFT_2021221.Data;
using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Repository
{
    public class BrandRepository : IBrandRepository
    {
        CarShopContext context;

        public BrandRepository(CarShopContext context)
        {
            this.context = context;
        }

        public void Create(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
        }

        public void Delete(int brandId)
        {
            context.Brands.Remove(ReadOne(brandId));
            context.SaveChanges();
        }

        public IQueryable<Brand> ReadAll()
        {
            return context.Brands;
        }

        public Brand ReadOne(int id)
        {
            return context
                .Brands
                .FirstOrDefault(b => b.Id == id);
        }

        public void Update(Brand brand)
        {
            Brand old = ReadOne(brand.Id);

            old.Cars = brand.Cars;
            old.Name = brand.Name;

            context.SaveChanges();
        }
    }
}
