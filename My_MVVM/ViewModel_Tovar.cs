using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace My_MVVM
{
    // связь 'View' и 'Model'
    public class ViewModel_Tovar : INotifyPropertyChanged
    {
        // определяем кол-цию товара, через кот. мы будем в 'ListBox' работать
        public ObservableCollection<Tovar> Tovares { get; set; }
        private Tovar selectTovar;

        public Tovar SelectTovar
        {
            get { return selectTovar; }
            set
            {
                selectTovar = value;
                // вызовем метод, кот. будет давать нам возм-ть оповещения об изм-ях этого товара
                OnPropCh("SelectTovar"); // изм-ие св-ва 'selectTovar'
            }
        }

        //1
        //public ViewModel_Tovar()
        //{
        //    // т.к. обычно мы берем кол-цию из внешнего файла, то здесь у нас происходит десериализация вместо создания
        //    Tovares = new ObservableCollection<Tovar>()
        //    {
        //         new Tovar{Title ="Молоко", Company="Ферма", Price=300},
        //         new Tovar{Title ="Хлеб", Company="Пончик", Price=100},
        //         new Tovar{Title ="Масло", Company="Ферма", Price=400},
        //         new Tovar{Title ="Апельсин", Company="Сад", Price=250}
        //    };
        //}

        public ViewModel_Tovar(DialogInterface _dialogInterface, IFileService _fileService)
        {
            dialogInterface = _dialogInterface;
            fileService = _fileService;

            Tovares = new ObservableCollection<Tovar>()
            {
                 new Tovar{Title ="Молоко", Company="Ферма", Price=300},
                 new Tovar{Title ="Хлеб", Company="Пончик", Price=100},
                 new Tovar{Title ="Масло", Company="Ферма", Price=400},
                 new Tovar{Title ="Апельсин", Company="Сад", Price=250}
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropCh([CallerMemberName] string prop_str = "")
        {
            if (PropertyChanged != null) // если мы выбрали св-во товара и оно не 'null', то вып-ем событие 'PropertyChanged' нашей строки - изменить ее
                PropertyChanged(this, new PropertyChangedEventArgs(prop_str));
        }

        // создаем команды
        private My_Command add_Command;
        public My_Command ADD_command
        { 
            get
            {
                // создадим новую команду как нам добавить новый обьект в нашу кол-цию
                // '??' - яв-ся ли он ссылочным об-ом и есть ли на него ссылка
                return add_Command ?? (add_Command = new My_Command
                     (obj =>
                     {
                         Tovar t1 = new Tovar();
                         Tovares.Insert(0, t1);
                         SelectTovar = t1;
                     }
                     ));
            }
        }
        private My_Command remove_command;
        public My_Command Remove_command
        {
            get 
            {
                return remove_command ?? (remove_command = new My_Command
                (obj =>
                {
                    Tovar t1 = obj as Tovar;
                    if (Tovares != null)
                        Tovares.Remove(t1);
                },
                (obj)=>Tovares.Count > 0)
                );
            }
            set { remove_command = value; }
        }

        IFileService fileService;
        DialogInterface dialogInterface;

        private My_Command saveCommand;
        public My_Command SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new My_Command(obj =>
                    {
                        try
                        {
                            if (dialogInterface.SaveFileDialog() == true)
                            {
                                fileService.Save(dialogInterface.FilePath, Tovares.ToList());
                                dialogInterface.Show_my("File saved");
                            }
                        }
                        catch (Exception ex) { dialogInterface.Show_my(ex.Message); }
                    }
                    )
                    );
            }
        }

        private My_Command openCommand;
        private Class_Dialog class_Dialog;
        private JsonSerialFile jsonSerialFile;

        public My_Command OpenCommand
        {
            get
            {
                return openCommand ??
                    (openCommand = new My_Command(obj =>
                    {
                        try
                        {
                            if (dialogInterface.OpenFileDialog() == true)
                            {
                                var tovars = fileService.Open(dialogInterface.FilePath);
                                Tovares.Clear();
                                foreach (var item in tovars)
                                {
                                    Tovares.Add(item);
                                }
                                dialogInterface.Show_my("File opend");
                            }
                        }
                        catch (Exception ex) { dialogInterface.Show_my(ex.Message); }
                    }
                    )
                    );
            }
        }
    }
}
