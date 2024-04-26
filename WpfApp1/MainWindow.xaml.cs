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
using System.Windows.Media.Animation; // для работы с анимациями
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
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

        private void picture_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var Anime = new DoubleAnimation(); // создаем анимацию с пом. 'DoubleAnimation()';
            Anime.From = 100; // с какуого размера начинается анимация
            Anime.To = 300; // по какой размер
            Anime.Duration = TimeSpan.FromSeconds(10); // сколько времени будет длиться анимация
            picture.BeginAnimation(WidthProperty, Anime); // анимация в ширину
            picture.BeginAnimation(HeightProperty, Anime); // анимация в высоту
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            var Anime = new DoubleAnimation();
            Anime.From = 300;
            Anime.To = 100;
            Anime.Duration = TimeSpan.FromSeconds(5);
            btn1.BeginAnimation(WidthProperty, Anime); // выполняем 'BeginAnimation' для св-ва ширины
        }
    }
}
