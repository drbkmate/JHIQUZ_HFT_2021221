using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Logic
{
    public interface ICarLogic
    {
        double AveragePrice();

        IEnumerable<KeyValuePair<string, double>> AveragePricesByBrands();
        IEnumerable<KeyValuePair<string, double>> AverageBmwPrices();
        IEnumerable<KeyValuePair<string, int>> MostExpensiveByBrands();
        IEnumerable<KeyValuePair<string, int>> BiggestEnginesByModels();
        IEnumerable<KeyValuePair<string, double>> AvgCcmDieselEngineAudies();

        void Create(Car car);
        Car ReadOne(int id);
        IQueryable<Car> ReadAll();
        void Update(Car car);
        void Delete(int carId);
    }
}
