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
    public class MainWindowEngineViewModel : ObservableRecipient
    {
        public RestCollection<Engine> Engines { get; set; }
        private Engine selectedEngine;

        public Engine SelectedEngine
        {
            get { return selectedEngine; }
            set
            {
                if (value != null)
                {
                    selectedEngine = new Engine()
                    {
                        Id = value.Id,
                        Ccm = value.Ccm,
                        Fuel = value.Fuel,
                        Cars = value.Cars
                    };
                    OnPropertyChanged();
                    (DeleteEngineCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        public ICommand CreateEngineCommand { get; set; }
        public ICommand DeleteEngineCommand { get; set; }
        public ICommand UpdateEngineCommand { get; set; }
        public MainWindowEngineViewModel()
        {

            Engines = new RestCollection<Engine>("http://localhost:51322/", "engine", "hub"); //BRAND HUB?
            CreateEngineCommand = new RelayCommand(() =>
            {
                Engines.Add(new Engine()
                {
                    Fuel = FuelType.Diesel,
                    Ccm = 3000
                });
            }
            );

            UpdateEngineCommand = new RelayCommand(() =>
            {
                Engines.Update(SelectedEngine);
            });

            DeleteEngineCommand = new RelayCommand(
            () =>
            {
                Engines.Delete(SelectedEngine.Id);
            },
            () =>
            {
                return SelectedEngine != null;
            }
            );
            SelectedEngine = new Engine();
        }
    }
}
