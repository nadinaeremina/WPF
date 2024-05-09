using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace English_for_kids
{
    /// <summary>
    /// Interaction logic for Go1.xaml
    /// </summary>
    public partial class Go1 : Window
    {
        //List<Bitmap> images = new List<Bitmap>();
        List<string> words = new List<string>();
        string[] right_answers = { "lion", "dog", "cat", "bird", "fish" };
        int ind1 = 0, ind2 = 1, ind3 = 2, right = 0, wrong = 0, limit_wrong = 5, inner_wrong = 1, left = 1, ind_right = 0, count = 60;
        bool flag = false;
        Timer timer = new Timer();

        public Go1(bool check, bool check2, bool check3)
        {
            words.Add("lion");
            words.Add("cat");
            words.Add("volf");

            words.Add("cow");
            words.Add("dog");
            words.Add("rabbit");

            words.Add("cat");
            words.Add("duck");
            words.Add("hamster");

            words.Add("sheep");
            words.Add("mouse");
            words.Add("bird");

            words.Add("horse");
            words.Add("fish");
            words.Add("pig");

            InitializeComponent();

            //FolderBrowserDialog folder = new FolderBrowserDialog();
            //folder.SelectedPath = "C:\\Users\\Nadya\\Desktop\\Новая папка";

            // обьект, кот. позволяет нам выбрать папочку, кот. будет помещать в себя опред. изоб-ие в нашу кол-цию 'images'
            //DirectoryInfo di = new DirectoryInfo("C:\\Users\\Nadya\\Desktop\\Новая папка"); // 'SelectedPath' - путь к выбранной папке

            //IEnumerable<FileInfo> files = di.EnumerateFiles(); // файлы могут быть разного формата - поэтому - IEnumerable
            //// 'EnumerateFiles()' - возвращ-ет кол-цию файлов из папки, кот. мы будем выбирать
            //foreach (FileInfo file in files)
            //{
            //    string str = System.IO.Path.GetExtension(file.FullName); // 'Path' (путь) - статич. класс
            //    // 'GetExtension' - возв-ет расширение у нашего об-та - 'FullName' - полное имя
            //    if (str == ".bmp" || str == ".jpeg" || str == ".png" || str == ".jpg")
            //    {
            //        Bitmap pt = new Bitmap(file.FullName); // укладываем в обьект 'BitMap' - нашу картинку
            //        // подгоняем наши картинки под один размер
            //        //Size pt_size = pictureBox1.Size;
            //        images.Add(new Bitmap(pt)); // укладываем картинку в коллекцию
            //    }
            //}

            answer.Items.Add(words[ind1]);
            answer.Items.Add(words[ind2]);
            answer.Items.Add(words[ind3]);

            now.Text = left.ToString();
            txt_right.Text = "0";
            txt_wrong.Text = "0";

            if (check == true)
            {
                txt_timer.Visibility = Visibility.Visible;
                txt_timer2.Visibility = Visibility.Visible;
                timer.Tick += new EventHandler(Show_timer);
                timer.Interval = 950;
                timer.Start();
            }
            if (check2 == true)
                limit_wrong = 3;
            if (check3 == true)
                inner_wrong = 2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (answer.SelectedItem != null)
            {
                if (answer.SelectedItem.ToString() == right_answers[ind_right])
                {
                    System.Windows.MessageBox.Show("Правильно!");
                    flag = false;
                    txt_right.Text = (++right).ToString();
                    ind_right++;
                }
                else
                {
                    System.Windows.MessageBox.Show("Ошибка!");
                    if (inner_wrong == 1 || flag)
                    {
                        ind_right++;
                        txt_wrong.Text = (++wrong).ToString();
                        flag = false;
                        if (wrong == limit_wrong)
                        {
                            System.Windows.MessageBox.Show("Вы допустили максимальное количество ошбок! Игра закончилась! Вы набрали 0 очков!");
                            Settings set = new Settings();
                            set.Show();
                            Close();
                            return;
                        }
                    }
                    else if (inner_wrong == 2 && !flag)
                    {
                        flag = true; 
                        System.Windows.MessageBox.Show("У вас есть еще 1 попытка!");
                    }
                }
            }
            else
                System.Windows.MessageBox.Show("Сначала выберите ответ!");

            if (inner_wrong == 1 || (inner_wrong == 2 && !flag))
            {
                ind1 += 3;
                ind2 += 3;
                ind3 += 3;

                if (left != 5)
                {
                    answer.Items.Clear();

                    answer.Items.Add(words[ind1]);
                    answer.Items.Add(words[ind2]);
                    answer.Items.Add(words[ind3]);
                }

                if (left == 1)
                    my_image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Nadya\\Desktop\\Новая папка\\dog.jpg");
                else if (left == 2)
                    my_image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Nadya\\Desktop\\Новая папка\\cat.jpg");
                else if (left == 3)
                    my_image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Nadya\\Desktop\\Новая папка\\orel.jpg");
                else if (left == 4)
                    my_image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("C:\\Users\\Nadya\\Desktop\\Новая папка\\fish.jpg");
                else if (left == 5)
                {
                    System.Windows.MessageBox.Show("Игра закончилась! Вы набрали очков");
                    Settings set = new Settings();
                    set.Show();
                    Close();
                    return;
                }
                now.Text = (++left).ToString();
            }  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("До новых встреч!");
            Settings set = new Settings();
            set.Show();
            Close();
        }

        private void Show_timer(object sender, EventArgs e)
        {
            txt_timer.Text = (--count).ToString();
        }
    }
}
