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
            for (int i = 0; i < players.Count; i++)
            {
                listbox.Items.Add(players[i]);
            }  
        }
    }
}
