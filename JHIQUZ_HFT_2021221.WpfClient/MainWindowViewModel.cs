using CommunityToolkit.Mvvm.ComponentModel;
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
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }
        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        Model = value.Model,
                        Id = value.Id,
                        BasePrice = value.BasePrice,
                        Brand = value.Brand,
                        BrandId = value.BrandId,
                        Engine = value.Engine,
                        EngineId = value.EngineId
                    };
                    OnPropertyChanged();
                    (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }

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
                    Model = "M240i",
                    Id = 100,
                    BrandId = 1,
                    BasePrice = 35000,
                    EngineId = 1
                }) ;
            }
            );

            UpdateCarCommand = new RelayCommand(()=> 
            {
                Cars.Update(SelectedCar);
            });

            DeleteCarCommand = new RelayCommand(
            () =>
            {
                Cars.Delete(SelectedCar.Id);
            },
            () =>
            {
              return SelectedCar != null;  
            }
            );
        }
    }
}
