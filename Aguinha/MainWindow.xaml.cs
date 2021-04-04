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
using Aguinha.Contexts;

namespace Aguinha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        private WaterIntakeContext context = new WaterIntakeContext();
        private NotificationContext notification = new NotificationContext();

        public MainWindow()
        {
            InitializeComponent();

            GlassDropdown.ItemsSource = context.Glasses;
            GlassDropdown.SelectedIndex = 0;

            DailyWaterGoalBar.Maximum = context.Intake.Goal;
        }

        private void DrinkWaterButton_Click(object sender, RoutedEventArgs e)
        {
            context.Drink();
            DailyWaterGoalBar.Value = context.Intake.Current;
        }

        private void ToastButton_Click(object sender, RoutedEventArgs e)
        {
            notification.ScheduleNotification(DateTime.Now.AddSeconds(5));
        }

        private void GlassDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = e.AddedItems[0];
            if (selection is Glass glass)
            {
                context.Glass = glass;

                var glassBitmapImage = new BitmapImage();
                glassBitmapImage.BeginInit();
                glassBitmapImage.UriSource = glass.Image;

                glassBitmapImage.DecodePixelWidth = Convert.ToInt32(GlassImage.Width);
                glassBitmapImage.EndInit();

                GlassImage.Source = glassBitmapImage;
            }
        }
    }
}
