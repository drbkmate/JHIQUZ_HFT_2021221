using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JHIQUZ_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CarPage carPage { get; set; }
        public BrandPage brandPage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            carPage = new CarPage();
            brandPage = new BrandPage();
        }

        private void CarTable_Click(object sender, RoutedEventArgs e)
        {
            TableField.Content = carPage;
        }

        private void BrandTable_Click(object sender, RoutedEventArgs e)
        {
            TableField.Content = brandPage;
        }

        private void EngineTable_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
