using JHIQUZ_HFT_2021221.Data;
using System;
using System.Linq;

namespace JHIQUZ_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CarShopContext ctx = new CarShopContext();

            var res1 = ctx.Cars.ToList();

            ;
        }
    }
}
