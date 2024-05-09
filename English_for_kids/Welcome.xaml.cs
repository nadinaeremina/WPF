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

        private void btn_go1_Click(object sender, RoutedEventArgs e)
        {
            Go1 form_go1 = new Go1();
            form_go1.ShowDialog();
            Close();
        }

        private void btn_go2_Click(object sender, RoutedEventArgs e)
        {
            Go1 form_go1 = new Go1();
            form_go1.ShowDialog();
            Close();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пока!");
            Close();
        }
    }
}
