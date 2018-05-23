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
    /// Interaction logic for TransferToPersonalBankAfterPandemicGame.xaml
    /// </summary>
    public partial class TransferToPersonalBankAfterPandemicGame : Page
    {
        ArrayList allPlayers = GameIO.load(0);
        ArrayList winningPlayers = new ArrayList();
        int numWinners = 0;
        int counter = 0;
        public TransferToPersonalBankAfterPandemicGame()
        {
            InitializeComponent();
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                if (((Game1)PandemicGameVictoryPointsAfterFinish.allPlayersAsGame1[i]).gameBalance > 100000)
                {
                    winningPlayers.Add(PandemicGameVictoryPointsAfterFinish.allPlayersAsGame1[i]);
                    numWinners++;
                }
                else
                {
                    ((Game1)PandemicGameVictoryPointsAfterFinish.allPlayersAsGame1[i]).gameBalance -= 100000.00;
                    Player temp = (Player)allPlayers[i];
                    Player.editBalance(ref temp, ((Game1)PandemicGameVictoryPointsAfterFinish.allPlayersAsGame1[i]).gameBalance);
                }
            }
            GameIO.save(allPlayers, 0);

            string output = "";
            if (numWinners > 0)
            {
                idLabel.Content = ((Player)allPlayers[((Game1)winningPlayers[0]).id - 1]).id.ToString();
                nameLabel.Content = ((Player)allPlayers[((Game1)winningPlayers[0]).id - 1]).firstName + " " + ((Player)allPlayers[((Game1)winningPlayers[0]).id - 1]).lastName;
                output += "+ " + ((Game1)winningPlayers[0]).gameBalance.ToString("F") + "\n";
                output += "- 100000.00\n";
                output += "- " + ((((Game1)winningPlayers[0]).gameBalance-100000)/2).ToString("F")  + "\n\n";
                output += "  " + ((((Game1)winningPlayers[0]).gameBalance-100000)/2).ToString("F");
                balancePreviewDynamicLabel.Content = output;
            }
            else
            {
                balancePreviewDynamicLabel.Content = "";
                doneLabel.Content = "DONE";
                idLabel.Content = "";
                nameLabel.Content = "";
                balancePreviewLabel.Content = "";
                balancePreviewLabel_Copy2.Content = "";
                balancePreviewLabel_Copy.Content = "";
            }
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            if (counter == numWinners)
            {
                return;
            }

            ((Player)allPlayers[((Game1)winningPlayers[counter]).id - 1]).balance += ((((Game1)winningPlayers[counter]).gameBalance - 100000) / 2);
            GameIO.save(allPlayers, 0);
            counter++;
            string output = "";
            if (counter < numWinners)
            {
                idLabel.Content = ((Player)allPlayers[((Game1)winningPlayers[counter]).id - 1]).id.ToString();
                nameLabel.Content = ((Player)allPlayers[((Game1)winningPlayers[counter]).id - 1]).firstName + " " + ((Player)allPlayers[((Game1)winningPlayers[counter]).id - 1]).lastName;
                output += "+ " + ((Game1)winningPlayers[counter]).gameBalance.ToString("F") + "\n";
                output += "- 100000.00\n";
                output += "- " + ((((Game1)winningPlayers[counter]).gameBalance - 100000) / 2).ToString("F") + "\n\n";
                output += "  " + ((((Game1)winningPlayers[counter]).gameBalance - 100000) / 2).ToString("F");
                balancePreviewDynamicLabel.Content = output;
            }
            else
            {
                balancePreviewDynamicLabel.Content = "";
                doneLabel.Content = "DONE";
                idLabel.Content = "";
                nameLabel.Content = "";
                balancePreviewLabel.Content = "";
                balancePreviewLabel_Copy2.Content = "";
                balancePreviewLabel_Copy.Content = "";
            }
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            if (counter == numWinners)
            {
                return;
            }
            counter++;
            string output = "";
            if (counter < numWinners)
            {
                idLabel.Content = ((Player)allPlayers[((Game1)winningPlayers[counter]).id - 1]).id.ToString();
                nameLabel.Content = ((Player)allPlayers[((Game1)winningPlayers[counter]).id - 1]).firstName + " " + ((Player)allPlayers[((Game1)winningPlayers[counter]).id - 1]).lastName;
                output += "+ " + ((Game1)winningPlayers[counter]).gameBalance.ToString("F") + "\n";
                output += "- 100000.00\n";
                output += "- " + ((((Game1)winningPlayers[counter]).gameBalance - 100000) / 2).ToString("F") + "\n\n";
                output += "  " + ((((Game1)winningPlayers[counter]).gameBalance - 100000) / 2).ToString("F");
                balancePreviewDynamicLabel.Content = output;
            }
            else
            {
                balancePreviewDynamicLabel.Content = "";
                doneLabel.Content = "DONE";
                idLabel.Content = "";
                nameLabel.Content = "";
                balancePreviewLabel.Content = "";
                balancePreviewLabel_Copy2.Content = "";
                balancePreviewLabel_Copy.Content = "";
            }
        }
    }
}
