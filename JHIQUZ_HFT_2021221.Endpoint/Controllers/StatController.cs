using JHIQUZ_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        private ICarLogic logic;

        public StatController(ICarLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet] //stat/avgprice
        public double GetAvgPrice()
        {
            return logic.AveragePrice();
        }

        [HttpGet] //stat/avgpricesbybrands
        public IEnumerable<KeyValuePair<string,double>> GetAvgPricesByBrands()
        {
            return logic.AveragePricesByBrands();
        }

        [HttpGet] //stat/avgbmwprices
        public IEnumerable<KeyValuePair<string, double>> GetAverageBmwPrices()
        {
            return logic.AverageBmwPrices();
        }

        [HttpGet] //stat/mostexpensivebybrands
        public IEnumerable<KeyValuePair<string, int>> GetMostExpensiveByBrands()
        {
            return logic.MostExpensiveByBrands();
        }

        [HttpGet] //stat/biggestenginesbymodels
        public IEnumerable<KeyValuePair<string, int>> GetBiggestEnginesByModels()
        {
            return logic.BiggestEnginesByModels();
        }

        [HttpGet] //stat/avgccmdieselengineaudies
        public IEnumerable<KeyValuePair<string, double>> GetAvgCcmDieselEngineAudies()
        {
            return logic.AvgCcmDieselEngineAudies();
        }
    }
}
