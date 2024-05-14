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
        // этот плеер больше для аудио
        MediaPlayer pl_1 = new MediaPlayer(); // создаем эл-т в классе окна, чтобы корректно отработал 'Close'
        // метод 'Close' вызывается автом-ки, когда обьект выходит из области видимости

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_open_audio_Click(object sender, RoutedEventArgs e)
        {
            // 1
            //pl_1.Open(new Uri("audio.mp3", UriKind.Relative)); // открыть аудиофайл // 'Relative' - относит. адрес
            //pl_1.Play(); // проигрываем // обязательный метод // будет сущ-ть на протяжении жизн. цикла окна
            
            // 2
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MP3 files (*.mp3)|*.mp3|All files(*.*)|*.*"; // 1 текст; 2 - то, что будет открываться
            if(ofd.ShowDialog()==true) // если выбран файл и нажата кнопка 'OK'
            {
                pl_1.Open(new Uri(ofd.FileName));
                pl_1.Play();
            }
        }
    }
}
