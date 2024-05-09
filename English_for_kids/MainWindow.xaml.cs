using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace English_for_kids
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btn_start.Visibility = Visibility.Hidden;
            Loading();
        }

        private async void Loading()
        {
            p_bar.Value = 0;

            do
            {
                p_bar.Value++;
                await Task.Delay(20);
                if (Convert.ToInt32(p_bar.Value) == 100)
                {
                    btn_start.Visibility = Visibility.Visible;
                    break;
                } 
            } while (true);
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            Settings f1 = new Settings();
            f1.Show();
            Close();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
