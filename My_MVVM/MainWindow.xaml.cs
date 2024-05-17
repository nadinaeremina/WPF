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

namespace My_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // устанавливаем контекст данных для данного окна и внего передать наш обьект 'ViewModel_Tovar'
            // это и есть наша связочка (каким образом из св-в товара через 'ViewModel' мы передаем наши данные на компановку
            
            // 1
            // привязываем класс 'ViewModel_Tovar'
            //DataContext = new ViewModel_Tovar(); // SelectedItem="{Binding SelectTovar}"
            
            //2
            DataContext = new ViewModel_Tovar(new Class_Dialog(), new JsonSerialFile()); // новый кон-р
        } 

        // Interface ICommand
        //bool CanExecute(object parameter); - может ли команда вып-ся
        //void Execute(object parameter); - метод, кот. вып-ет логику команды
        //event EventHandler CanExecuteChanged; - выз-ся при измен-ии усл-ий CanExecute
    }
}
