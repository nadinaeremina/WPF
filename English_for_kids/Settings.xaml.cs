using System;
using System.Collections.Generic;
using System.IO;
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
                if (txt_lastname.Text.Length > 0)
                {
                    if (txt_age.Text.Length > 0)
                    {
                        if (int.TryParse(txt_age.Text, out chislo) == true && Convert.ToInt32(txt_age.Text) > 3 && Convert.ToInt32(txt_age.Text) < 18)
                        {
                            string filePath = "players.txt";
                            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                            {
                                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                                {
                                    sw.Write(txt_name.Text);
                                    sw.Write(" ");
                                    sw.Write(txt_lastname.Text);
                                    sw.Write(" ");
                                    sw.Write(txt_age.Text);
                                    sw.Write("/");
                                    sw.Dispose();
                                }
                            }
                            MessageBox.Show("Данные сохранены!");

                            //using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                            //{
                            //    string readText = sr.ReadToEnd();
                            //    sr.Dispose();
                            //    Read reading = new Read(readText);
                            //    reading.Show();
                            //}
                            
                            Welcome f2 = new Welcome(txt_name.Text);
                            f2.Show();
                            Close();
                        }
                        else
                            MessageBox.Show("Некорректный возраст!");
                    }
                    else
                        MessageBox.Show("Введите возраст!");
                }
                else
                    MessageBox.Show("Введите фамилию!");
            }
            else
                MessageBox.Show("Введите имя!");
        }

        private void new_player_Click(object sender, RoutedEventArgs e)
        {
            st_panel_auto.Visibility = Visibility.Visible;
            enter_age.Visibility = Visibility.Visible;
            txt_age.Visibility = Visibility.Visible;
        }
        private void ex_player_Click(object sender, RoutedEventArgs e)
        {
            st_panel_auto.Visibility = Visibility.Visible;
            enter_age.Visibility = Visibility.Hidden;
            txt_age.Visibility = Visibility.Hidden;
        }
        private void rating_Click(object sender, RoutedEventArgs e)
        {
            Rating rating_form = new Rating();
            rating_form.Show();
        }
        private void info_Click(object sender, RoutedEventArgs e)
        {
            Info info_form = new Info();
            info_form.Show();
        }
        private void exit_player_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("До новых встреч!");
            Close();
        }
    }
}
