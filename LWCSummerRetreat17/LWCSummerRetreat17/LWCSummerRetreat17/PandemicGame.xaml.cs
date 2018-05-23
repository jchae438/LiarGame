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
    /// Interaction logic for PandemicGame.xaml
    /// </summary>
    public partial class PandemicGame : Page
    {
        public static ArrayList allPlayersAsGame1 = new ArrayList();
        public Boolean[,] hasConnected = new Boolean[GameIO.numPlayers, GameIO.numPlayers];
        public static Boolean[] gotVictoryPoint = new Boolean[GameIO.numPlayers];
        public PandemicGame()
        {
            InitializeComponent();
            allPlayersAsGame1 = GameIO.load(1);
            int numYes = 0;
            int numNo = 0;

            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                if (Game1Form.playerVotes[i] == true)
                {
                    numYes++;
                }
                else
                {
                    numNo++;
                }
            }

            Boolean minority;
            if (numYes > numNo)
            {
                minority = false;
            }
            else if (numYes < numNo)
            {
                minority = true;
            }
            else
            {
                minority = false;
            }

            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                if (Game1Form.playerVotes[i] == minority)
                {
                    ((Game1)allPlayersAsGame1[i]).isInfected = false;
                    ((Game1)allPlayersAsGame1[i]).vaccines = Game1Form.numVaccines;
                }
                else
                {
                    ((Game1)allPlayersAsGame1[i]).isInfected = true;
                }
            }

            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                for (int j = 0; j < GameIO.numPlayers; j++)
                {
                    hasConnected[i, j] = false;
                }
            }

            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                gotVictoryPoint[i] = false;
            }
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean isDoubleFuse = (Boolean)doubleFuse.IsChecked;

            if (isValidID(player1TB.Text) == false)
            {
                successLabel.Content = "";
                errorIDLabel.Content = "Please enter valid ID for Player 1.";
                return;
            }

            if (isValidID(player2TB.Text) == false) 
            {
                successLabel.Content = "";
                errorIDLabel.Content = "Please enter valid ID for Player 2.";
                return;
            }
            
            int id1; int.TryParse(player1TB.Text, out id1);
            int id2; int.TryParse(player2TB.Text, out id2);
            Game1 player1 = (Game1)allPlayersAsGame1[id1 - 1];
            Game1 player2 = (Game1)allPlayersAsGame1[id2 - 1];

            if (hasConnected[(id1 - 1),(id2 - 1)] == true)
            {
                successLabel.Content = "";
                errorIDLabel.Content = "Players have already connected.";
                doubleFuse.IsChecked = false;
                return;
            }

            if (player1.isInfected == false && player2.isInfected == false)//neither infected
            {
                if (isDoubleFuse)
                {
                    player1.vaccines += 2;
                    player2.vaccines += 2;
                }
                else
                {
                    player1.vaccines++;
                    player2.vaccines++;
                }
            }
            else if (player1.isInfected == true && player2.isInfected == false)//player1 infected
            {
                if(player1.vaccines == 0 && player2.vaccines == 0)
                {
                    player2.isInfected = true;
                }
                else if (player1.vaccines == 0 && player2.vaccines > 0)
                {
                    player1.isInfected = false;
                    player2.isInfected = true;
                    player2.vaccines--;
                }
                else if (player1.vaccines > 0 && player2.vaccines == 0)
                {
                    player2.isInfected = true;
                }
                else if (player1.vaccines > 0 && player2.vaccines > 0)
                {
                    player1.isInfected = false;
                    player2.isInfected = true;
                    player2.vaccines--;
                }
            }
            else if (player1.isInfected == false && player2.isInfected == true)//player2 infected
            {
                if (player1.vaccines == 0 && player2.vaccines == 0)
                {
                    player1.isInfected = true;
                }
                else if (player1.vaccines == 0 && player2.vaccines > 0)
                {
                    player1.isInfected = true;
                }
                else if (player1.vaccines > 0 && player2.vaccines == 0)
                {
                    player1.isInfected = true;
                    player2.isInfected = false;
                    player1.vaccines--;
                }
                else if (player1.vaccines > 0 && player2.vaccines > 0)
                {
                    player2.isInfected = false;
                    player1.isInfected = true;
                    player1.vaccines--;
                }
            }
            errorIDLabel.Content = "";
            successLabel.Content = "ID:" + player1.id.ToString() + " and ID:" + player2.id.ToString() + " successfully connected.";
            doubleFuse.IsChecked = false;
            hasConnected[(id1 - 1), (id2 - 1)] = true;
        }

        private void player2TB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Boolean isDoubleFuse = (Boolean)doubleFuse.IsChecked;

                if (isValidID(player1TB.Text) == false)
                {
                    successLabel.Content = "";
                    errorIDLabel.Content = "Please enter valid ID for Player 1.";
                    return;
                }

                if (isValidID(player2TB.Text) == false)
                {
                    successLabel.Content = "";
                    errorIDLabel.Content = "Please enter valid ID for Player 2.";
                    return;
                }
                
                int id1; int.TryParse(player1TB.Text, out id1);
                int id2; int.TryParse(player2TB.Text, out id2);
                Game1 player1 = (Game1)allPlayersAsGame1[id1 - 1];
                Game1 player2 = (Game1)allPlayersAsGame1[id2 - 1];

                if (hasConnected[(id1 - 1), (id2 - 1)] == true)
                {
                    successLabel.Content = "";
                    errorIDLabel.Content = "Players have already connected.";
                    doubleFuse.IsChecked = false;
                    return;
                }

                if (player1.isInfected == false && player2.isInfected == false)//neither infected
                {
                    if (isDoubleFuse)
                    {
                        player1.vaccines += 2;
                        player2.vaccines += 2;
                    }
                    else
                    {
                        player1.vaccines++;
                        player2.vaccines++;
                    }
                }
                else if (player1.isInfected == true && player2.isInfected == false)//player1 infected
                {
                    if (player1.vaccines == 0 && player2.vaccines == 0)
                    {
                        player2.isInfected = true;
                    }
                    else if (player1.vaccines == 0 && player2.vaccines > 0)
                    {
                        player1.isInfected = false;
                        player2.isInfected = true;
                        player2.vaccines--;
                    }
                    else if (player1.vaccines > 0 && player2.vaccines == 0)
                    {
                        player2.isInfected = true;
                    }
                    else if (player1.vaccines > 0 && player2.vaccines > 0)
                    {
                        player1.isInfected = false;
                        player2.isInfected = true;
                        player2.vaccines--;
                    }
                }
                else if (player1.isInfected == false && player2.isInfected == true)//player2 infected
                {
                    if (player1.vaccines == 0 && player2.vaccines == 0)
                    {
                        player1.isInfected = true;
                    }
                    else if (player1.vaccines == 0 && player2.vaccines > 0)
                    {
                        player1.isInfected = true;
                    }
                    else if (player1.vaccines > 0 && player2.vaccines == 0)
                    {
                        player1.isInfected = true;
                        player2.isInfected = false;
                        player1.vaccines--;
                    }
                    else if (player1.vaccines > 0 && player2.vaccines > 0)
                    {
                        player2.isInfected = false;
                        player1.isInfected = true;
                        player1.vaccines--;
                    }
                }
                errorIDLabel.Content = "";
                successLabel.Content = "ID:" + player1.id.ToString() + " and ID:" + player2.id.ToString() + " successfully connected.";
                doubleFuse.IsChecked = false;
                hasConnected[(id1 - 1), (id2 - 1)] = true;
            }
        }

        private void nextRoundButton_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < GameIO.numPlayers; i++)
            {
                Game1 temp = (Game1)allPlayersAsGame1[i];
                if((temp.vaccines >= 3 && temp.isInfected == false) || (temp.vaccines >= 4 && temp.isInfected == true))
                {
                    temp.victoryPoints++;
                    gotVictoryPoint[i] = true;
                }
            }
            GameIO.save(allPlayersAsGame1, 1);
            PandemicGameVictoryPointsAfterRepeat form = new PandemicGameVictoryPointsAfterRepeat();
            Game1Form win = (Game1Form)Window.GetWindow(this);
            win.Content = form;
        }

        private void useVaccineButton_Click(object sender, RoutedEventArgs e)
        {
            PandemicGameUseVaccineForm form = new PandemicGameUseVaccineForm();
            form.Show();
        }

        private void playerStatusButton_Click(object sender, RoutedEventArgs e)
        {
            PandemicGamePlayerStatusForm window = new PandemicGamePlayerStatusForm();
            window.Show();
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
