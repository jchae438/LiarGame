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
    /// Interaction logic for MusicalChairsResultsPage.xaml
    /// </summary>
    public partial class MusicalChairsResultsPage : Page
    {
        private static ArrayList allPlayers = GameIO.load(0);
        private static ArrayList lostOneLife = new ArrayList();
        private static ArrayList lostTwoLives = new ArrayList();

        public MusicalChairsResultsPage()
        {
            InitializeComponent();
            minoritygametitle.Content = "-Musical Chairs Round " + (GameIO.game2Round-1).ToString() + " Results-";
            eliminatedPlayers.Content = "";
            Boolean[] affectedThisRound = new Boolean[GameIO.numPlayers];
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                affectedThisRound[i] = false;
            }
            int numLostALife = 0;
            int numLostTwoLives = 0;
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                Game2 temp = (Game2)Game2Form.allPlayersAsGame2[i];
                Player temp2 = (Player)allPlayers[i];
                if (temp.didSit == false)
                {
                    temp.currentCPassID = 0;
                    temp.prevCPassID = 0;
                    affectedThisRound[i] = true;
                    temp.isEliminated++;
                }
            }

            for (int j = 0; j < GameIO.numPlayers; j++)
            {
                Game2 temp = (Game2)Game2Form.allPlayersAsGame2[j];
                Player temp2 = (Player)allPlayers[j];
                if (temp.isEliminated == 1 && affectedThisRound[j])
                {
                    numLostALife++;
                    eliminatedPlayers.Content += "-" + temp2.firstName + " " + temp2.lastName + "\n";
                }
            }

            if (numLostALife == 1)
            {
                eliminatedPlayers.Content += "has lost a life.\n";
            }
            else if (numLostALife > 1)
            {
                eliminatedPlayers.Content += "have each lost a life.\n";
            }

            for (int k = 0; k < GameIO.numPlayers; k++)
            {
                Game2 temp = (Game2)Game2Form.allPlayersAsGame2[k];
                Player temp2 = (Player)allPlayers[k];
                if (temp.isEliminated == 2 && affectedThisRound[k])
                {
                    numLostTwoLives++;
                    eliminatedPlayers.Content += "-" + temp2.firstName + " " + temp2.lastName + "\n";
                }
            }

            if (numLostTwoLives == 1)
            {
                eliminatedPlayers.Content += "has been eliminated.";
            }
            else if (numLostTwoLives > 1)
            {
                eliminatedPlayers.Content += "have been eliminated.";
            }

            if (numLostALife == 0 && numLostTwoLives == 0)
            {
                eliminatedPlayers.Content += "No players have lost any lives.";
            }


            GameIO.save(Game2Form.allPlayersAsGame2, 2);
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            int numSurvivors = 0;
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                Game2 temp = (Game2)Game2Form.allPlayersAsGame2[i];
                if (temp.isEliminated <= 1)
                {
                    numSurvivors++;
                }
            }

            if (numSurvivors <= 2)
            {
                MusicalChairsFinalWinnersPage page = new MusicalChairsFinalWinnersPage();
                Game2Form win = (Game2Form)Window.GetWindow(this);
                win.Content = page;
            }
            else
            {
                MusicalChairsElectionPage page = new MusicalChairsElectionPage();
                Game2Form win = (Game2Form)Window.GetWindow(this);
                win.Content = page;
            }
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            MusicalChairsFinalWinnersPage page = new MusicalChairsFinalWinnersPage();
            Game2Form win = (Game2Form)Window.GetWindow(this);
            win.Content = page;
            //left off here, make the final musical winners display page 
        }
    }
}
