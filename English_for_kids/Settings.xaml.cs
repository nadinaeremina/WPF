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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int chislo;
            if (txt_name.Text.Length > 0)
            {
                if (txt_age.Text.Length > 0)
                {
                    if (int.TryParse(txt_age.Text, out chislo) == true &&  Convert.ToInt32(txt_age.Text) > 3 && Convert.ToInt32(txt_age.Text) < 18)
                    {
                        Welcome f2 = new Welcome(txt_name.Text);

                        f2.ShowDialog();
                        //f2.Show();
                        Close();
                    }
                    else
                        MessageBox.Show("Incorrect age!");
                }
                else
                    MessageBox.Show("Please, enter your age!");
            }
            else
                MessageBox.Show("Please, enter your name!");
        }
    }
}
