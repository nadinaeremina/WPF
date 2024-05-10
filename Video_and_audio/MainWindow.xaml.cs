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

namespace Video_and_audio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer pl_1 = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_open_audio_Click(object sender, RoutedEventArgs e)
        {
            //pl_1.Open(new Uri("audio.mp3", UriKind.Relative));
            //pl_1.Play();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MP3 files (*.mp3)|*.mp3||All files(*.*)|*.*"; // 1 текст, 2 то, что будет открываться
            if(ofd.ShowDialog()==true)
            {
                pl_1.Open(new Uri(ofd.FileName));
                pl_1.Play();
            }
        }
    }
}
