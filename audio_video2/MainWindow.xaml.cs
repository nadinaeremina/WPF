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
            ofd.AddExtension = true;
            ofd.Filter = "MP4 files (*.mp4)|*.mp4|All files(*.*)|*.*";
            ofd.ShowDialog();
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
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            slider_video.Value = medelem.Position.TotalSeconds;
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
        {
            TimeSpan ts = TimeSpan.FromSeconds(e.NewValue);// новое значение
            medelem.Position = ts;
        }

        private void slider_audio_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            medelem.Volume = slider_audio.Value;
        }

        private void medelem_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (medelem.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(medelem.NaturalDuration.TimeSpan.TotalMilliseconds);
                slider_video.Maximum = ts.TotalSeconds;
            }
        }
    }
}
