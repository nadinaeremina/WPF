using Microsoft.Win32;
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
using System.Windows.Threading;

namespace audio_video2
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

        private void btn_open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true; // при открытии файла будет добавлять расширение автомат-ки
            ofd.Filter = "MP4 files (*.mp4)|*.mp4|All files(*.*)|*.*";

            ofd.ShowDialog(); // if (ofd.ShowDialog() == true) заменили на блок try-catch
            try
            {
                medelem.Source = new Uri(ofd.FileName);
            }
            catch (Exception)
            {
                new NullReferenceException("Error uri!");
            }

            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(timer_Tick);
            // dt.Interval = TimeSpan.FromSeconds(5.0f); // действие будет выпол-ся раз в 5 секунд // 'TimeSpan' - стр-ра
            dt.Interval = new TimeSpan(0,0,1); // создали новый об-т с необ-ми пар-ми: 0 часов, 0 минут, 1 секунда
            dt.Start();
            // dt.IsEnabled = true; // то же самое, что и 'Start'
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            slider_video.Value = medelem.Position.TotalSeconds; // передаем позицию времени, а именно секунды
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            medelem.Play();
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            medelem.Pause();
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            medelem.Stop();
        }

        private void slider_video_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            // событие, связанное с изменением значения слайдера пользователем
        {
            TimeSpan ts = TimeSpan.FromSeconds(e.NewValue);// создаем стр-ру и помещаем в нее новое текущее значение
            medelem.Position = ts; // 'Position' - позиция видео
        }

        private void slider_audio_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            medelem.Volume = slider_audio.Value; // 'Volume' - звук видео
        }

        // событие, связанное с тем, как будет открываться наш медиа файл
        private void medelem_MediaOpened(object sender, RoutedEventArgs e)
        {
            // 'NaturalDuration' - получает естественную продолж-ть мультимелиа
            // 'HasTimeSpan' - получает значение, указывающее, представляет ли данный объект Duration значение TimeSpan
            // значение "true", если данной длительности присвоено значение TimeSpan; в остальных случаях — "false".
            if (medelem.NaturalDuration.HasTimeSpan) // получил ли наш медиа эл-т нужное знач-ие по видеофайлику
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(medelem.NaturalDuration.TimeSpan.TotalMilliseconds);
                slider_video.Maximum = ts.TotalSeconds;
                // слайдер будет работать до макс. знач-ия нашего видеофайлика
            }
        }

        // LoadedBehavior="Manual" - св-во, кот. позволит нам проигрывать медиафайл
    }
}
