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
    public class MainWindowBrandViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }
        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Name = value.Name

                    };
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        public MainWindowBrandViewModel()
        {

            Brands = new RestCollection<Brand>("http://localhost:51322/", "brand", "hub"); //BRAND HUB?
            CreateBrandCommand = new RelayCommand(() =>
            {
                Brands.Add(new Brand()
                {
                    Name = "Misubishi"
                });
            }
            );

            UpdateBrandCommand = new RelayCommand(() =>
            {
                Brands.Update(SelectedBrand);
            });

            DeleteBrandCommand = new RelayCommand(
            () =>
            {
                Brands.Delete(SelectedBrand.Id);
            },
            () =>
            {
                return SelectedBrand != null;
            }
            );
            SelectedBrand = new Brand(); //nem dob null ref. exceptiont ha nincs kiválasztva semmi
        }
    }
}
