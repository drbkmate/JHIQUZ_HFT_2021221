using HFT_FF_L08.Client;
using JHIQUZ_HFT_2021221.Models;
using System;
using System.Linq;

namespace JHIQUZ_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            CarShopContext ctx = new CarShopContext();

            var res1 = ctx.Cars.ToList();

            ;*/

            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:51322");

            var cars = rest.Get<Car>("car");
            var brands = rest.Get<Car>("brand");
            var engines = rest.Get<Car>("engine");

            ;

        }
    }
}
