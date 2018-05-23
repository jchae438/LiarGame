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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LWCSummerRetreat17
{
    /// <summary>
    /// Interaction logic for MusicalChairsElectionPage.xaml
    /// </summary>
    public partial class MusicalChairsElectionPage : Page
    {

        public static int[] votes = new int[GameIO.numPlayers];
        public MusicalChairsElectionPage()
        {
            InitializeComponent();
            minoritygametitle.Content = "-Election Round " + (GameIO.game2Round - 1).ToString() + "-";
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                votes[i] = 0;
            }
        }

        private void voteButton_Click(object sender, RoutedEventArgs e)
        {
            if (isValidID(playerID.Text))
            {
                if (isValidID(candidateID.Text))
                {
                    int candID = int.Parse(candidateID.Text);
                    if (((Game2)Game2Form.allPlayersAsGame2[candID - 1]).isEliminated <= 1)
                    {
                        votes[candID - 1]++;
                        errorLabel.Content = "";
                        successLabel.Content = "Player ID:" + playerID.Text + "voted for Candidate ID:" + candidateID.Text + ".";
                    }
                    else
                    {
                        errorLabel.Content = "Candidate is an eliminated player.";
                        successLabel.Content = "";
                    }
                }
                else
                {
                    errorLabel.Content = "Please enter valid candidate ID.";
                    successLabel.Content = "";
                }
            }
            else
            {
                errorLabel.Content = "Please enter valid Player ID.";
                successLabel.Content = "";
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            //left off right here 
            MusicalChairsElectionResultsPage page = new MusicalChairsElectionResultsPage();
            Game2Form win = (Game2Form)Window.GetWindow(this);
            win.Content = page;
        }

        private Boolean isValidID(string id)
        {
            int n;
            if (int.TryParse(id, out n))
            {
                if (n >= 1 && n <= GameIO.numPlayers)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
