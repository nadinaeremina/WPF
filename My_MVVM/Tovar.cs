using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace My_MVVM
{
    public class Tovar : INotifyPropertyChanged // реализация интерфейса
    {
        // данный интерфейс реализует всего один метод 'OnPropCh'
        // для того, чтобы изменения были мы создаем у каждого св-ва этот метод
        // этот метод будет работать, когда мы будем в св-ве что-то менять

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropCh("Title");
            }
        }
        private string company;
        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropCh("Company");
            }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropCh("Price");
            }
        }
        public Tovar()
        {
        }
        public Tovar(string title, string company, int price)
        {
            this.title = title;
            this.company = company;
            this.price = price;
        }

        public event PropertyChangedEventHandler PropertyChanged; // изменение каких-либо св-в и вызывать событие по его индексу

        void OnPropCh([CallerMemberName] string prop_str = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop_str));
        }
    }
}
