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

namespace My_resource10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // не создаем в 'App', потому что будем пользоваться по нажатию кнопки
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("Skin1.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;
            LabelSkin.Content = "Скин 1";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("Skin2.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;
            LabelSkin.Content = "Скин 2";
        }
    }
}
