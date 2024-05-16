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
using System.Windows.Shapes;

namespace English_for_kids
{
    /// <summary>
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Rating : Window
    {
        public Rating(List<Player> players)
        {
            InitializeComponent();

            players.Sort();
            players.Reverse();

            for (int i = 0; i < players.Count; i++)
                players[i].Number = i + 1;

            listbox1.Items.Add("№");
            listbox2.Items.Add("Имя");
            listbox3.Items.Add("Фамилия");
            listbox4.Items.Add("Возраст");
            listbox5.Items.Add("Очки");

            for (int i = 0; i < 5; i++)
            {
                listbox1.Items.Add(players[i].Number);
                listbox2.Items.Add(players[i].First_name);
                listbox3.Items.Add(players[i].Last_name);
                listbox4.Items.Add(players[i].Age);
                listbox5.Items.Add(players[i].Rating); 
            }
        }
    }
}
