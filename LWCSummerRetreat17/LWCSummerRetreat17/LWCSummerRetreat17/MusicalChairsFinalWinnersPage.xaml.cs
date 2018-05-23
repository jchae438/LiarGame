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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LWCSummerRetreat17
{
    /// <summary>
    /// Interaction logic for MusicalChairsFinalWinnersPage.xaml
    /// </summary>
    
    public partial class MusicalChairsFinalWinnersPage : Page
    {
        public static ArrayList allPlayersAsGame2 = GameIO.load(2);
        private static ArrayList allPlayers = GameIO.load(0);

        public MusicalChairsFinalWinnersPage()
        {
            InitializeComponent();

            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                Game2 temp = (Game2)allPlayersAsGame2[i];
                Player temp2 = (Player)allPlayers[i];
                if (temp.isEliminated <= 1)
                {
                    finalWinnerLabel.Content += temp2.firstName + " " + temp2.lastName + "\n";
                }
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            MusicalChairsTokenPage page = new MusicalChairsTokenPage();
            Game2Form win = (Game2Form)Window.GetWindow(this);
            win.Content = page;
        }
    }
}
