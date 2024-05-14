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
using System.Xml;
using System.Xml.Serialization;

namespace English_for_kids
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        bool exicting = false;
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
                    if ((txt_age.Text.Length > 0 && !exicting) || exicting)
                    {
                        if ((!exicting && int.TryParse(txt_age.Text, out chislo) == true && Convert.ToInt32(txt_age.Text) > 3 && Convert.ToInt32(txt_age.Text) < 18) || exicting)
                        {
                            if (!exicting)
                            {
                                MessageBox.Show("Данные сохранены!");
                                Welcome f2 = new Welcome(txt_name.Text, txt_lastname.Text, Convert.ToInt32(txt_age.Text), exicting);
                                f2.Show();
                                Close();
                            }
                                
                            else
                            {
                                bool flag = false;
                                StreamReader reader = new StreamReader(@"C:\\Users\\Nadya\\Desktop\\Players.txt", true);
                                string str = reader.ReadToEnd();
                                string[] mas = str.Split('/');
                                List<string> list = new List<string>();
                                list.AddRange(mas);

                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i].Contains(txt_name.Text) && list[i].Contains(txt_lastname.Text))
                                    {
                                        flag = !flag;
                                        break;
                                    }
                                }
                                reader.Close();
                                if (flag)
                                {
                                    int a = Convert.ToInt32(txt_age.Text);
                                    MessageBox.Show("Данные верны! Такой игрок существует!");
                                    Welcome f2 = new Welcome(txt_name.Text, txt_lastname.Text, a, exicting);
                                    f2.Show();
                                    Close();
                                }
                                else
                                    MessageBox.Show("Данные неверны! Такого игрока не существует!");
                            }
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
            new_or_exist.Text = "Регистрация нового игрока";
            exicting = false;
            st_panel_auto.Visibility = Visibility.Visible;
            enter_age.Visibility = Visibility.Visible;
            txt_age.Visibility = Visibility.Visible;
        }
        private void ex_player_Click(object sender, RoutedEventArgs e)
        {
            new_or_exist.Text = "Авторизация существующего игрока";
            exicting = true;
            st_panel_auto.Visibility = Visibility.Visible;
            enter_age.Visibility = Visibility.Hidden;
            txt_age.Visibility = Visibility.Hidden;
        }
        private void rating_Click(object sender, RoutedEventArgs e)
        {
            StreamReader reader = new StreamReader(@"C:\\Users\\Nadya\\Desktop\\Players.txt", true);
            string str = reader.ReadToEnd();
            reader.Close();
            
            List<Player> players = new List<Player>();
            string[] mas = str.Split('/');
            string[] my_str;

            for (int i = 0; i < mas.Length; i++)
            {
                my_str = mas[i].Split(' ');
                if (my_str.Length == 4)
                    players.Add(new Player { First_name = my_str[0], Last_name = my_str[1], Age = Convert.ToInt32(my_str[2]), Rating = my_str[3]});   
            }

            Rating rating_form = new Rating(players);
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

        private void txt_name_TextChanged(object sender, TextChangedEventArgs e) // рег выр!!!!!!!
        {
            var simvols = new HashSet<char>("!~@#$%^&*()_+-=\\/' \":;><.,`№[]{}|");
            string stroka = txt_name.Text;
            bool cont_any = stroka.Any(simvols.Contains);
            if (cont_any)
                txt_name.Text = txt_name.Text.Remove(txt_name.Text.Length - 1);
        }

        private void txt_name_KeyUp(object sender, KeyEventArgs e)
        {
            //var simvols = new HashSet<char>("!~@#$%^&*()_+-=\\/'\":;><.,`№[]{}|");
            //string stroka = txt_name.Text;
            //bool cont_any = stroka.Any(simvols.Contains);
            //if (cont_any)
            //    txt_name.Text = txt_name.Text.Remove(txt_name.Text.Length - 1);
        }

        private void txt_name_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            //var simvols = new HashSet<char>("!~@#$%^&*()_+-=\\/ '\":;><.,`№[]{}|");
            //string stroka = txt_name.Text;
            //bool cont_any = stroka.Any(simvols.Contains);
            //if (cont_any)
            //    txt_name.Text = txt_name.Text.Remove(txt_name.Text.Length - 1);
        }
    }
}
