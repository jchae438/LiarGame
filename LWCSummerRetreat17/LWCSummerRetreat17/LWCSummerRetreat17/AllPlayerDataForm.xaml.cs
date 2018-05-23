using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LWCSummerRetreat17
{
    /// <summary>
    /// Interaction logic for AllPlayerDataForm.xaml
    /// </summary>
    public partial class AllPlayerDataForm : Window
    {

        public class PlayerGrid
        {
            public int ID { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public double Balance { get; set; }
        }

        ObservableCollection<PlayerGrid> gridSourceIDSort = new ObservableCollection<PlayerGrid>();
        ObservableCollection<PlayerGrid> gridSourceBalanceSort = new ObservableCollection<PlayerGrid>();

        public class PlayerComparer : IComparer
        {
            public int Compare(object a, object b)
            {
                Player pa = a as Player;
                Player pb = b as Player;
                if (pa == pb) return 0;
                if (pa == null) return -1;
                if (pb == null) return 1;

                return -1 * pa.balance.CompareTo(pb.balance);
            }

        }

        public AllPlayerDataForm()
        {
            InitializeComponent();
            // allPlayerDataGrid.ItemsSource = gridSource;
            ArrayList allPlayers = GameIO.load(0);
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
               //allPlayerDataGrid.Items.Add(new PlayerGrid(){ idCol = allPlayers[i].id, firstNameCol = allPlayers[i].firstName, lastNamecol = allPlayers[i].lastName, balanceCol = allPlayers[i].balance});
               gridSourceIDSort.Add(new PlayerGrid() {ID = ((Player)allPlayers[i]).id, First_Name = ((Player)allPlayers[i]).firstName, Last_Name = ((Player)allPlayers[i]).lastName, Balance = ((Player)allPlayers[i]).balance});
            }
            allPlayerDataGrid.ItemsSource = gridSourceIDSort;
            allPlayers.Sort(0,GameIO.numPlayers, new PlayerComparer());
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                //allPlayerDataGrid.Items.Add(new PlayerGrid(){ idCol = allPlayers[i].id, firstNameCol = allPlayers[i].firstName, lastNamecol = allPlayers[i].lastName, balanceCol = allPlayers[i].balance});
                gridSourceBalanceSort.Add(new PlayerGrid() { ID = ((Player)allPlayers[i]).id, First_Name = ((Player)allPlayers[i]).firstName, Last_Name = ((Player)allPlayers[i]).lastName, Balance = ((Player)allPlayers[i]).balance });
            }
        }

        private void idSort_Click(object sender, RoutedEventArgs e)
        {
            allPlayerDataGrid.ItemsSource = gridSourceIDSort;
        }

        private void balanceSort_Click(object sender, RoutedEventArgs e)
        {
            allPlayerDataGrid.ItemsSource = gridSourceBalanceSort;
        }
    }
}
