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

namespace My_binding_homework
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

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Binding binding = new Binding();
                binding.Source = listBox1;// Источник 
                binding.Path = new PropertyPath("Content");
                binding.Mode = BindingMode.OneWay;

                txt_edit.SetBinding(TextBox.TextProperty, binding);
            }
            else
                MessageBox.Show("Сначала выберите позицию!");



            //
        }
    }
}
