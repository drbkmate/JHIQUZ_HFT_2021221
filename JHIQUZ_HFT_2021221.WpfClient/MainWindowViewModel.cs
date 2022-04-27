using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Car> Cars { get; set; }
        public MainWindowViewModel()
        {
            Cars = new RestCollection<Car>("http://localhost:51322/", "car");
        }
    }
}
