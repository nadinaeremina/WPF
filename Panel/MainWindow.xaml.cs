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

namespace Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
        WPF - .NET (подсистема для графического интерфейса такжк, как и Windows Forms)
        wf - OSW -> User32, GDI+ (отвечают за графику)
        WPF - DirectX (отвечают за графику) 3D-mod, аппаратное ускорение (работают засчет DirectX) - в WPF быстрее прорисовка
        1 аппаратная единица = 1/96 дюйма
        
        WPF:
        1) XAML - декларативная разметка (с пом. XAML мы можем работать на большинстве управляемых языках)
        2) независимость от разрешения экрана (резиновость)
        3) 3D-mod, привязка данных (из одного эл-та в другой), стили, шаблоны, темы, скины...
        4) взаимодействие с WF (можно исп-ть эл-ты из WF)
        5) подходит для множества сис-м OSW
        6) для более качественной графики можно исп-ть доп. биб-ки - Monogame, Unity GUI, SDLib, RayLib
         */
        public MainWindow()
        {
            InitializeComponent(); // точка входа
        }
    }
}
