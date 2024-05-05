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
    /// Interaction logic for Go1.xaml
    /// </summary>
    public partial class Go1 : Window
    {
        List<Image> images = new List<Image>();
        List<string> words = new List<string>();
        public Go1()
        {
            words.Add("lion");
            words.Add("cat");
            words.Add("volf");
            words.Add("dog");
            words.Add("orel");
            words.Add("fish");
            InitializeComponent();
            btn1.Content = words[0];
            btn2.Content = words[1];
            btn3.Content = words[2];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Right!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wrong!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wrong!");
        }
    }
}
