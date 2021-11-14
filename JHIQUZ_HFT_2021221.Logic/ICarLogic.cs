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

        IEnumerable<KeyValuePair<string, double>>
            AveragePricesByBrands();
    }
}
