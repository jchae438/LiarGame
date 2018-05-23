using System;
using System.Collections;
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

namespace LWCSummerRetreat17
{
    /// <summary>
    /// Interaction logic for MusicalChairsAllPlayerDataWindow.xaml
    /// </summary>
    public partial class MusicalChairsAllPlayerDataWindow : Window
    {
        public class PlayerGrid
        {
            public int ID { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public int Remaining_Lives { get; set; }
            public string Sitting { get; set; }
            public int Current_Chair { get; set; }
        }

        private ArrayList allPlayers = GameIO.load(0);
        private ArrayList allPlayersAsGame2 = new ArrayList();
        public MusicalChairsAllPlayerDataWindow()
        {
            InitializeComponent();
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                string isSitting = "";
                int curChair = -1;
                if (((Game2)Game2Form.allPlayersAsGame2[i]).didSit)
                {
                    isSitting = "Yes";
                    curChair = ((Game2)Game2Form.allPlayersAsGame2[i]).currentCPassID;
                }
                else
                {
                    isSitting = "No";
                }

                int remLives = 0;
                if (((Game2)Game2Form.allPlayersAsGame2[i]).isEliminated == 0)
                {
                    remLives = 2;
                }
                else if (((Game2)Game2Form.allPlayersAsGame2[i]).isEliminated == 1)
                {
                    remLives = 1;
                }

                allPlayersAsGame2.Add(new PlayerGrid() { ID = ((Player)allPlayers[i]).id, First_Name = ((Player)allPlayers[i]).firstName, Last_Name = ((Player)allPlayers[i]).lastName, Remaining_Lives = remLives, Current_Chair = curChair, Sitting = isSitting });
            }
            allPlayerDataGrid.ItemsSource = allPlayersAsGame2;
        }
    }
}
