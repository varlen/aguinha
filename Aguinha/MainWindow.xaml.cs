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

using Aguinha.Models;

namespace Aguinha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Glass> Glasses = new List<Glass>{
            new Glass { 
                Name = "Copo Americano", 
                CapacityMililiters = 200, 
                Image = new Uri("/Images/copo americano.jpg", UriKind.Relative)
            },
            new Glass
            {
                Name = "Copão",
                CapacityMililiters = 350,
                Image = new Uri("/Images/pint.jpg", UriKind.Relative)
            }
        };

        public MainWindow()
        {
            InitializeComponent();

            this.GlassDropdown.ItemsSource = this.Glasses;
            this.GlassDropdown.SelectedIndex = 0;
        }



        private void DrinkWaterButton_Click(object sender, RoutedEventArgs e)
        {
            this.DailyWaterGoalBar.Value += 10;
        }
    }
}
