using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace My_MVVM
{
    public class My_Command : ICommand
    {
        // создаем делегаты для того, чтобы обраб-ть наши команды
        Action<object> execute; // принимает 1 пар-р
        Func<object, bool> canExecute; // принимает 2 пар-ра

        // развернутая подписка на событие
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }
        public My_Command(Action<object> _execute, Func<object, bool> _canExecute=null)
        {
            execute = _execute;
            canExecute = _canExecute;
        }
        // здесь проверяем, пустая команда или задана
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }
        // здесь вып-ем эту команду
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
