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

            if (players.Count > 5)
                players.RemoveAt(5);

            for (int i = 0; i < players.Count; i++)
                listbox.Items.Add(players[i]);
        }
    }
}
