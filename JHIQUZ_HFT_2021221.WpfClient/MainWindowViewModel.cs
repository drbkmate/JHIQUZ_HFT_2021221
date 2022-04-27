using CommunityToolkit.Mvvm.Input;
using JHIQUZ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JHIQUZ_HFT_2021221.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Car> Cars { get; set; }
        public ICommand CreateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }
        public MainWindowViewModel()
        {
            Cars = new RestCollection<Car>("http://localhost:51322/", "car");
            CreateCarCommand = new RelayCommand(() =>
            {
                Cars.Add(new Car()
                {
                    Model = "Ssangyong",
                    Id = 10
                });
            }
);
        }
    }
}
