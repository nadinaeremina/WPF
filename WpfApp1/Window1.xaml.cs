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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        bool flag = false;

        private void Picture_load(object sender, MouseButtonEventArgs e)
        {
            flag =! flag;
            var Anime = new DoubleAnimation();
            if(flag == true)
            {
                Anime.From = 1;
                Anime.To = 0;
            }
            else
            {
                Anime.From = 0;
                Anime.To = 1;
            }
            Anime.Duration = TimeSpan.FromSeconds(5);
            p2.BeginAnimation(OpacityProperty, Anime);
        }

        private void p1_Loaded(object sender, RoutedEventArgs e)
        {
            // в 'XML' - св-во 'Source' // 'Relative' - лежат в корне проекта
            p1.Source = new BitmapImage(new Uri("1.jpg", UriKind.Relative)); 
            p2.Source = new BitmapImage(new Uri("2.jpg", UriKind.Relative));

            // в 'XML' - св-во 'Alignment' // выравнивание по верхнему левому углу
            p1.HorizontalAlignment = HorizontalAlignment.Left;
            p2.HorizontalAlignment = HorizontalAlignment.Left;
            p1.VerticalAlignment = VerticalAlignment.Top;
            p2.VerticalAlignment = VerticalAlignment.Top;

            // в 'XML' - св-ва 'Width' и 'Height'//
            p1.Width = 590; 
            p1.Height = 260;
            p2.Width = 590; 
            p2.Height = 260;

            // в 'XML' - св-ва 'Margin' // отступы left, top, right, bottom
            p1.Margin = new Thickness(10, 10, 0, 0);
            p2.Margin = new Thickness(10, 10, 0, 0);

            // обработчики - когда нажмем на картинку - произойдет 'Picture_Load'
            p1.MouseDown += new MouseButtonEventHandler(Picture_load); 
            p2.MouseDown += new MouseButtonEventHandler(Picture_load);
            p1.Opacity = 1; // для того, чтобы одна картинка была видна, а вторая закрыта
        }
    }
}
