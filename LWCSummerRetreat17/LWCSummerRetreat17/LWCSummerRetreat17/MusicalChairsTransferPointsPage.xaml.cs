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
    /// Interaction logic for MusicalChairsTransferPointsPage.xaml
    /// </summary>
    public partial class MusicalChairsTransferPointsPage : Page
    {
        ArrayList allPlayers = GameIO.load(0);
        public static ArrayList winners = new ArrayList();
        int numWinners = 0;
        int counter = 0;
        public MusicalChairsTransferPointsPage()
        {
            InitializeComponent();
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                if (MusicalChairsTokenPage.gameBalances[i] > 100000)
                {
                    winners.Add(i);
                    numWinners++;
                }
                else
                {
                    Player temp = (Player)allPlayers[i];
                    Player.editBalance(ref temp, -100000 + MusicalChairsTokenPage.gameBalances[i]);
                }
            }

            GameIO.save(allPlayers, 0);

            string output = "";
            if (numWinners > 0)
            {
                idLabel.Content = ((Player)allPlayers[(int)winners[0]]).id.ToString();
                nameLabel.Content = ((Player)allPlayers[(int)winners[0]]).firstName + " " + ((Player)allPlayers[(int)winners[0]]).lastName;
                output += "+ " + MusicalChairsTokenPage.gameBalances[(int)winners[0]].ToString("F") + "\n";
                output += "- 100000.00\n";
                output += "- " + ((MusicalChairsTokenPage.gameBalances[(int)winners[0]] - 100000) / 2).ToString("F") + "\n\n";
                output += "  " + ((MusicalChairsTokenPage.gameBalances[(int)winners[0]] - 100000) / 2).ToString("F");
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

            ((Player)allPlayers[(int)winners[counter]]).balance += ((MusicalChairsTokenPage.gameBalances[(int)winners[0]] - 100000) / 2);
            GameIO.save(allPlayers, 0);
            counter++;
            string output = "";

            if (counter < numWinners)
            {
                idLabel.Content = ((Player)allPlayers[(int)winners[counter]]).id.ToString();
                nameLabel.Content = ((Player)allPlayers[(int)winners[counter]]).firstName + " " + ((Player)allPlayers[(int)winners[counter]]).lastName;
                output += "+ " + MusicalChairsTokenPage.gameBalances[(int)winners[counter]].ToString("F") + "\n";
                output += "- 100000.00\n";
                output += "- " + ((MusicalChairsTokenPage.gameBalances[(int)winners[counter]] - 100000) / 2).ToString("F") + "\n\n";
                output += "  " + ((MusicalChairsTokenPage.gameBalances[(int)winners[counter]] - 100000) / 2).ToString("F");
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
                idLabel.Content = ((Player)allPlayers[(int)winners[counter]]).id.ToString();
                nameLabel.Content = ((Player)allPlayers[(int)winners[counter]]).firstName + " " + ((Player)allPlayers[(int)winners[counter]]).lastName;
                output += "+ " + MusicalChairsTokenPage.gameBalances[(int)winners[counter]].ToString("F") + "\n";
                output += "- 100000.00\n";
                output += "- " + ((MusicalChairsTokenPage.gameBalances[(int)winners[counter]] - 100000) / 2).ToString("F") + "\n\n";
                output += "  " + ((MusicalChairsTokenPage.gameBalances[(int)winners[counter]] - 100000) / 2).ToString("F");
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
