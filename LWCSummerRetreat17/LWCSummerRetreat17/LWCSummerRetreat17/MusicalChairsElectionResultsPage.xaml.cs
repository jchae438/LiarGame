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
    /// Interaction logic for MusicalChairsElectionResultsPage.xaml
    /// </summary>
    public partial class MusicalChairsElectionResultsPage : Page
    {
        private ArrayList allPlayers = GameIO.load(0);
        public MusicalChairsElectionResultsPage()
        {
            InitializeComponent();
            primaryWinnersLabel.Content = "";
            secondaryWinnersLabel.Content = "";
            tertiaryWinnersLabel.Content = "";
            minoritygametitle.Content = "- Election Round " + (GameIO.game2Round - 1).ToString() + " Results-";
            int maxVotes = 0;
            for (int j = 0; j < GameIO.numPlayers; j++)
            {
                if (MusicalChairsElectionPage.votes[j] > maxVotes)
                {
                    maxVotes = MusicalChairsElectionPage.votes[j];
                }
            }

            int numPlayersWithOneVote = 0;
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                Player player = (Player)allPlayers[i];
                if (MusicalChairsElectionPage.votes[i] == maxVotes)
                {
                    primaryWinnersLabel.Content += player.firstName + " " + player.lastName + " - " + maxVotes.ToString() + "\n";
                }
                else if (MusicalChairsElectionPage.votes[i] > 1 && MusicalChairsElectionPage.votes[i] < maxVotes)
                {
                    secondaryWinnersLabel.Content += player.firstName + " " + player.lastName + " - " + MusicalChairsElectionPage.votes[i].ToString() + "\n";
                }
                else if (MusicalChairsElectionPage.votes[i] == 1)
                {
                    numPlayersWithOneVote++;
                }
            }

            if (numPlayersWithOneVote == 1)
            {
                tertiaryWinnersLabel.Content = numPlayersWithOneVote.ToString() + " other player received 1 vote.";
            }
            else if (numPlayersWithOneVote > 1)
            {
                tertiaryWinnersLabel.Content = numPlayersWithOneVote.ToString() + " other players received 1 vote each.";
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            MusicalChairsEliminationPage page = new MusicalChairsEliminationPage();
            Game2Form win = (Game2Form)Window.GetWindow(this);
            win.Content = page;
        }
    }
}
