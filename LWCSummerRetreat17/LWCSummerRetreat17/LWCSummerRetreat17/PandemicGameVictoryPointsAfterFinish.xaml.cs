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
    /// Interaction logic for PandemicGameVictoryPointsAfterFinish.xaml
    /// </summary>
    public partial class PandemicGameVictoryPointsAfterFinish : Page
    {
        public static ArrayList allPlayersAsGame1 = GameIO.load(1);
        public PandemicGameVictoryPointsAfterFinish()
        {
            InitializeComponent();
            string winners = "";
            ArrayList allPlayers = GameIO.load(0);
            int totalVictoryPoints = 0;
            double prizePool = 100000 * GameIO.numPlayers;
            //get total number of victory points
            for (int j = 0; j < GameIO.numPlayers; j++)
            {
                Game1 temp = (Game1)allPlayersAsGame1[j];
                totalVictoryPoints += temp.victoryPoints;
            }

            //award money to each player from prize pool according to victory points
            for (int k = 0; k < GameIO.numPlayers; k++)
            {
                Game1 temp = (Game1)allPlayersAsGame1[k];
                if (temp.victoryPoints > 0)
                {
                    double percentage = (double)temp.victoryPoints / (double)totalVictoryPoints;
                    temp.gameBalance += percentage * prizePool;
                    temp.gameBalance = Math.Round(temp.gameBalance, 2);
                }
            }

            for (int p = 0; p < GameIO.numPlayers; p++)
            {
                Game1 temp = (Game1)allPlayersAsGame1[p];
                Player temp2 = (Player)allPlayers[p];
                if (temp.gameBalance > 0)
                {
                    winners += "-" + temp2.firstName + " " + temp2.lastName + " +" + temp.victoryPoints.ToString() + "VP" + " (+" + temp.gameBalance.ToString("F") + " Pts)" + "\n";
                }
            }

            listOfWinners.Content = winners;
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            TransferToPersonalBankAfterPandemicGame form = new TransferToPersonalBankAfterPandemicGame();
            Game1Form win = (Game1Form)Window.GetWindow(this);
            win.Content = form;
        }
    }
}
