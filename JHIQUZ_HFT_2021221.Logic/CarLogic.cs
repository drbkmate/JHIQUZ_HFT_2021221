using JHIQUZ_HFT_2021221.Models;
using JHIQUZ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Logic
{
    public class CarLogic : ICarLogic
    {
        ICarRepository repo;

        public CarLogic(ICarRepository repo)
        {
            this.repo = repo;
        }

        public double AveragePrice()
        {
            return repo
                .ReadAll()
                .Average(c => c.BasePrice) ?? 0; // double.NaN
        }

        public IEnumerable<KeyValuePair<string, double>> AveragePricesByBrands()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.Brand)
                .Select(x => new KeyValuePair<string, double>(x.Key.Name, x.Average(c => c.BasePrice) ?? 0));
        }
        public IEnumerable<KeyValuePair<string, double>> AverageBmwPrices()
        {
            return repo
                .ReadAll()
                .Where(y => y.Brand.Name == "BMW")
                .GroupBy(x => x.Brand)
                .Select(x => new KeyValuePair<string, double>(x.Key.Name, x.Average(c => c.BasePrice) ?? 0));
        }
        //Most expensive car by brands
        public IEnumerable<KeyValuePair<string, int>> MostExpensiveByBrands()
        {
            return repo
                .ReadAll()                
                .GroupBy(x => x.Brand)
                .Select(x => new KeyValuePair<string, int>(x.Key.Name, x.Max(c => c.BasePrice) ?? 0));
        }
        //Biggest ccm engines by models
        /*public IEnumerable<KeyValuePair<string, int>> BiggestEnginesByBrands()
        {
            
            return repo
                .ReadAll()
                .GroupBy(x => x.Model)
                .Select(x => new KeyValuePair<string, int>(x.Key, x.Where);
                //.Select(x => new KeyValuePair<string, int>(x.Key.Name, x.Max(c => c.EngineId) ?? 0));
        }*/
    }
}
