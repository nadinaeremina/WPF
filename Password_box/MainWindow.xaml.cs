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

namespace Password_box
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        bool flag = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_copy_Click(object sender, RoutedEventArgs e)
        {
            if (scratchTextBox.Text.Length > 0)
            {
                if (listMaskChar.SelectedItem == null)
                    MessageBox.Show("Сначала выберите маску!");
                else
                {
                    // 'SelectAll' все, что было выбрано
                    scratchTextBox.SelectAll();
                    // скопировать
                    scratchTextBox.Copy();
                    flag = true;
                }
            }
            else
                MessageBox.Show("Сначала введите пароль!");
        }

        // что делать с выбранным эл-ом
        private void listMaskChar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // выбранным символом в 'PasswordBox' будет заменяться пароль
            pwdBox.PasswordChar = ((ComboBoxItem)listMaskChar.SelectedItem).Content.ToString().ToCharArray()[0];
            // тк мы выбрали 'SelectedItem'(он приводит к типу 'object') - приводим к типу 'ComboBoxItem'
        }

        private void bt_paste_Click(object sender, RoutedEventArgs e)
        {
            if (scratchTextBox.Text.Length > 0)
            {
                if (flag)
                {
                    // очищаем
                    pwdBox.Clear();
                    // очищаем
                    scratchTextBox.Clear();
                    // в 'PasswordBox' вставляем
                    pwdBox.Paste();
                    flag = false;
                }
                else
                    MessageBox.Show("Сначала нажмите 'копировать'!");
            }
            else
                MessageBox.Show("Сначала введите пароль!");
        }

        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            // 'PasswordBox' очищаем
            pwdBox.Clear();
        }

        // замена символов реальных на значки
        private void pwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            count++;
            pwChagesLabel.Content = count;
        }

        private void scratchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (selectMaxLen.SelectedItem == null)
            {
                if (scratchTextBox.Text.Length > 0)
                {
                    scratchTextBox.Clear();
                    MessageBox.Show("Сначала настройте количество символов !");
                }
            }
            else
            {
                currentLen.Content = Convert.ToInt32(((ListBoxItem)selectMaxLen.SelectedItem).Content.ToString()) - scratchTextBox.Text.Length;
                if (scratchTextBox.Text.Length > Convert.ToInt32(((ListBoxItem)selectMaxLen.SelectedItem).Content.ToString()))
                {
                    scratchTextBox.Text = (scratchTextBox.Text.ToString()).Remove(scratchTextBox.Text.Length - 1);
                    MessageBox.Show("Слишком много символов!");
                }
            }
        }
    }
}
