﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace English_for_kids
{
    /// <summary>
    /// Interaction logic for Go1.xaml
    /// </summary>
    public partial class Go1 : Window
    {
        string first_name, last_name, my_str, new_str = "";
        string[] right_answers = { "lion", "dog", "cat", "bird", "fish" };
        int ind1 = 0, ind2 = 1, ind3 = 2, right = 0, wrong = 0, limit_wrong = 5, inner_wrong = 1, left = 1, ind_right = 0, count = 60, age;
        bool sound = true;

        private void btn_sound_Click(object sender, RoutedEventArgs e)
        {
            if (sound)
            {
                btn_sound.Content = "Включить звук";
                media_pl.Stop();
            } 
            else
            {
                btn_sound.Content = "Выключить звук";
                media_pl.Play();
            }
            sound = !sound;
        }

        bool flag = false, existing;

        List<string> words = new List<string>();
        DispatcherTimer dt = new DispatcherTimer();
        MediaPlayer media_pl = new MediaPlayer(); 

        public Go1(bool check, bool check2, bool check3, string str1, string str2, int agee, bool exist)
        {
            media_pl.Open(new Uri("C:\\Users\\Nadya\\source\\repos\\WpfApp1\\English_for_kids\\audio4.mp3"));
            media_pl.Play();

            first_name = str1;
            last_name = str2;
            age = agee;
            existing = exist;

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
                it_image.Visibility = Visibility.Visible;
                dt.Tick += new EventHandler(Show_timer);
                dt.Interval = TimeSpan.FromSeconds(1);
                dt.Start();
            }
            if (check == false)
                it_image2.Visibility = Visibility.Visible;
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
                            right = 0;
                            System.Windows.MessageBox.Show($"Вы допустили максимальное количество ошбок! Игра закончилась! Вы набрали {right} очков!");
                            media_pl.Stop();
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
                    System.Windows.MessageBox.Show($"Игра закончилась! Вы набрали {right} очков");

                    if (!existing)
                    {
                        StreamWriter writer = new StreamWriter(@"C:\\Users\\Nadya\\Desktop\\Players.txt", true);
                        writer.Write(first_name);
                        writer.Write(" ");
                        writer.Write(last_name);
                        writer.Write(" ");
                        writer.Write(age);
                        writer.Write(" ");
                        writer.Write(right);
                        writer.Write("/");
                        writer.Close();
                    }
                    else
                    {
                        List<string> my_list;
                        List<string> list;
                        using (StreamReader reader = new StreamReader(@"C:\\Users\\Nadya\\Desktop\\Players.txt", true))
                        {
                            string str = reader.ReadToEnd();
                            string[] mas = str.Split('/');
                            list = new List<string>(mas);
                            list.RemoveAt(list.Count - 1);

                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i].Contains(first_name) && list[i].Contains(last_name))
                                {
                                    my_str = list[i];
                                    list.RemoveAt(i);
                                    break;
                                }
                            }

                            string[] mas2 = my_str.Split(' ');
                            my_list = new List<string>(mas2);
                            my_list[3] = (Convert.ToInt32(my_list[3]) + right).ToString();
                            my_str = "";

                            for (int i = 0; i < my_list.Count; i++)
                            {
                                my_str += my_list[i];
                                if (i < my_list.Count - 1)
                                    my_str += ' ';
                            }
                            my_str += "/";

                            for (int i = 0; i < list.Count; i++)
                                list[i] += '/';

                            list.Add(my_str);
                            //reader.Close();
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\\Users\\Nadya\\Desktop\\Players.txt"))
                        {
                            for (int i = 0; i < list.Count; i++)
                                new_str += list[i];
                            writer.Write(new_str);
                            //writer.Close();
                        }
                    }

                    media_pl.Stop();
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
            media_pl.Stop();
            System.Windows.MessageBox.Show("До новых встреч!");
            Settings set = new Settings();
            set.Show();
            Close();
        }

        private void Show_timer(object sender, EventArgs e)
        {
            if (txt_timer2.Text != "0")
                txt_timer2.Text = (--count).ToString();
            else
            {
                dt.Stop();
                right = 0;
                System.Windows.MessageBox.Show($"К сожалению, Вам не хватило времени! Вы набрали {right} очков"); media_pl.Stop();
                Settings set = new Settings();
                set.Show();
                Close();
            }
        }
    }
}
