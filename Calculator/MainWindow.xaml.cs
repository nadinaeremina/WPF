using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isOperation = false, isEqual = false, isCE = false;
        string before_result = "", before_operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        // функция, производящая расчеты
        private void Computer()
        {
            if (before_result.Length > 0 && before_operation.Length > 0) // если есть предыдущее число и сохраненный предыдущий оператор
            {
                switch (before_operation)
                {
                    case "/":
                        result.Text = (Double.Parse(before_result) / Convert.ToDouble(result.Text, NumberFormatInfo.InvariantInfo)).ToString();
                        break;

                    case "*":
                        result.Text = (Double.Parse(before_result) * Convert.ToDouble(result.Text, NumberFormatInfo.InvariantInfo)).ToString();
                        break;

                    case "+":
                        result.Text = (Double.Parse(before_result) + Convert.ToDouble(result.Text, NumberFormatInfo.InvariantInfo)).ToString();
                        break;

                    case "-":
                        result.Text = (Double.Parse(before_result) - Convert.ToDouble(result.Text,NumberFormatInfo.InvariantInfo)).ToString();
                        break;
                }
            }
        }

        // событие, возникающее при нажатии на цифру или запятую 
        private void Button_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            isCE = false;

            if ((result.Text == "0" && button.Content.ToString() != "." && button.Content.ToString() != "0") || (isOperation)) // избавляемся от нуля, при нажатии на цифру
                result.Clear();

            if (isEqual == false)
            {
                if (button.Content.ToString() == ".") // если была нажата клавиша 'запятая' - проверяем, есть ли она уже в числе
                {
                    if (!result.Text.Contains("."))
                    {
                        if (result.Text.Length == 0) // если запятая нажата в первый раз и это первый введенный символ, то ставим в начале числа ноль
                        {
                            result.Text += "0"; // в окне 'result' 
                            current.Text += "0"; // в окне 'current' 
                        }

                        if (current.Text.Length == 0) // если запятая нажата в первый раз и это первый введенный символ, то ставим в начале числа ноль в окне 'current'
                            current.Text += "0";
                        else
                            result.Text += button.Content.ToString(); // если нажата запятая в первый раз - и это не первый введенный символ - то печатаем запятую в окне 'result'


                        current.Text += button.Content.ToString(); // если нажата запятая в первый раз - печатаем запятую в окне 'result'
                    }
                }
                else
                {
                    if (button.Content.ToString() == "0")
                    {
                        if (result.Text.Length == 1)
                        {
                            if (current.Text.Length > 0 && current.Text[current.Text.Length - 1] != '0')
                            {
                                current.Text = current.Text.Remove(current.Text.Length - 1);
                            }
                            result.Text = "0";
                        }

                        if (isCE == false && result.Text.Length > 1)
                        {
                            current.Text += button.Content.ToString();
                            result.Text += button.Content.ToString(); // если была нажата цифра - добавляем ее в окно 'result'
                        }
                        else if ((result.Text.Contains("0") && result.Text.Contains(".")) || (result.Text.Length == 0))
                        {
                            result.Text += button.Content.ToString(); // если была нажата цифра - добавляем ее в окно 'result'
                            current.Text += button.Content.ToString();
                        }
                    }
                    else
                    {
                        if (result.Text.Length == 0)
                        {
                            if (current.Text.Length > 0 && current.Text[current.Text.Length - 1] == '0')
                            {
                                current.Text = current.Text.Remove(current.Text.Length - 1);
                            }
                        }
                        result.Text += button.Content.ToString(); // если была нажата цифра - добавляем ее в окно 'result'
                        if (result.Text != "0" || button.Content.ToString() == "0") // если это не ноль - добавляем в окно 'current'
                        {
                            current.Text += button.Content.ToString();
                        }
                    }
                }
            }

            isOperation = false; // сработала кнопка, вызывающая операцию
        }

        // событие, возникающее при нажатии на тип операции
        private void Button_operation(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            int count = 0;
            // не допускаем, чтобы число с плавающей точкой заканчивалось 0 или запятой
            do
            {
                if (result.Text.Contains(".") && result.Text[result.Text.Length - 1] == '0')
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1);
                    count++;
                }
                else break;

            } while (true);

            // удаляем ненужные нули
            if (count > 0)
                current.Text = current.Text.Remove(current.Text.Length - count, count);


            if (isEqual == true) // если сработало равно
            {
                before_result = result.Text;
                before_operation = button.Content.ToString();
                current.Text += button.Content.ToString();
                isEqual = false;

                if (current.Text[current.Text.Length - 1] == '.') // если последний введенный символ в окне 'current' - запятая, то мы избавляемся от нее в окне 'current'
                    current.Text = current.Text.Remove(current.Text.Length - 1);

                isOperation = true;
            }
            else
            {
                if (result.Text != "0" || (current.Text.Length > 0 && current.Text[current.Text.Length - 1] == '0') || (before_result == "0")) // действия происходят, если в окне 'result' есть какие-то цифры
                {
                    if (result.Text[result.Text.Length - 1] == '.') // если последний введенный символ в окне 'result' - запятая, то мы избавляемся от нее в окне 'result'
                        result.Text = result.Text.Remove(result.Text.Length - 1);

                    if (current.Text[current.Text.Length - 1] == '.') // если последний введенный символ в окне 'current' - запятая, то мы избавляемся от нее в окне 'current'
                        current.Text = current.Text.Remove(current.Text.Length - 1);

                    if (isOperation == true || isCE == true) // если была нажата кнопка операции и сработла снова подряд - старую операцию меняем на новую
                    {
                        current.Text = current.Text.Remove(current.Text.Length - 1);
                        current.Text += button.Content.ToString();
                        before_operation = button.Content.ToString();
                    }
                    else // перед кнопкой операции были нажаты кнопки цифр
                    {
                        if (current.Text.Length > 0)
                        {
                            current.Text += button.Content.ToString(); //после операции были нажаты кнопки цифр

                            Computer(); // вызываем функцию выполнения операции

                            isOperation = true; // операция выполнена
                            before_operation = button.Content.ToString(); // запоминаем текущую операцию
                            before_result = result.Text; // запоминаем текущее число
                        }
                    }
                }
            }
            if (isCE)
            {
                if (current.Text.Length > 0)
                {
                    current.Text = current.Text.Remove(current.Text.Length - 1);
                    current.Text += button.Content.ToString();
                    before_operation = button.Content.ToString();
                }
            }
        }

        // получение результата
        private void button_equal_Click_1(object sender, RoutedEventArgs e)
        {
            // если перед этим не было равно и знаков операций
            if (isEqual == false && (result.Text != "0" || (current.Text.Length > 0 && current.Text[current.Text.Length - 1] == '0')) || (result.Text == "0" && before_result == "0"))
            {
                if (current.Text[current.Text.Length - 1] != '+' && current.Text[current.Text.Length - 1] != '-' && current.Text[current.Text.Length - 1] != '*' && current.Text[current.Text.Length - 1] != '/')
                {
                    Computer(); // вызываем функцию выполнения операции
                    isEqual = true;
                }
            }
        }

        // событие, очищающее поле 'result'
        private void button_CE_Click_1(object sender, RoutedEventArgs e)
        {
            if (isEqual == false)
            {
                if (result.Text.Length > 0) // если число есть в окне 'result'
                {
                    if (current.Text.Length > 0)
                    {
                        // проверяем есть ли у нас в окне 'result' введенное число или это рез-т предыдущего вычисления
                        if (current.Text[current.Text.Length - 1] != '+' && current.Text[current.Text.Length - 1] != '-' && current.Text[current.Text.Length - 1] != '*' && current.Text[current.Text.Length - 1] != '/')
                        {
                            int length = result.Text.Length; // запоминаем его длину
                            current.Text = current.Text.Remove(current.Text.Length - length, length); // удаляем число из окна 'current'
                            result.Text = "0"; // обнуляем 'result'
                        }
                    }
                }
            }
            isCE = true;
        }

        // событие, очищающее последний введенный символ
        private void button_clear_1_Click_1(object sender, RoutedEventArgs e)
        {

            if (isEqual == false)
            {
                if (result.Text != "0") // если есть введенный символы
                {
                    if (current.Text.Length > 0)
                    {
                        // проверяем есть ли у нас в окне 'result' введенное число или это рез-т предыдущего вычисления
                        if (current.Text[current.Text.Length - 1] != '+' && current.Text[current.Text.Length - 1] != '-' && current.Text[current.Text.Length - 1] != '*' && current.Text[current.Text.Length - 1] != '/')
                        {
                            result.Text = result.Text.Remove(result.Text.Length - 1); // очищаем поле 'result' от одного символа
                            current.Text = current.Text.Remove(current.Text.Length - 1); // очищаем поле 'current' от одного символа
                        }
                    }
                }
            }
        }

        // событие, очищающее поле 'result' и поле 'current'
        private void button_C_Click(object sender, RoutedEventArgs e)
        {
            if (result.Text.Length > 0)
            {
                result.Text = "0"; // обнуляем 'result'
                // проверяем есть ли у нас в окне 'result' введенное число или это рез-т предыдущего вычисления
                if (current.Text.Length > 0)
                {
                    current.Clear(); // очищаем 'current'
                }
                before_result = ""; // очищаем переменную, содержащую предыдущее число  
                before_operation = ""; // очищаем переменную, содержащую предыдущеюю операцию
            }
            result.Text = "0";
            isEqual = false;
        }
    }
}
