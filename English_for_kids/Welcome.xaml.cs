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
using System.Windows.Shapes;

namespace English_for_kids
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome(string name)
        {
            InitializeComponent();
            welcome.Title = $"Добро пожаловать, {name}!";
        }

        private void choose_Clickc(object sender, RoutedEventArgs e)
        {
            Go1 form_go1 = new Go1(check_time.IsChecked.Value, wrongs.IsChecked.Value, onemore_try.IsChecked.Value);
            form_go1.Show();
            Close();
        }

        private void choose2_Clickc(object sender, RoutedEventArgs e)
        {
            Go2 form_go2 = new Go2(check_time2.IsChecked.Value, wrongs2.IsChecked.Value, onemore_try2.IsChecked.Value);
            form_go2.Show();
            Close();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пока!");
            Close();
        }
    }
}
