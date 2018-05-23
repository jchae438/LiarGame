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
    /// Interaction logic for Game1Form.xaml
    /// </summary>
    public partial class Game1Form : Window
    {
        private int counter = 0;
        public int numYes = 0;
        public int numNo = 0;
        private static ArrayList allPlayers = GameIO.load(0);
        public static Boolean[] playerVotes = new Boolean[GameIO.numPlayers];
        public static int numVaccines = 0;
        public static int minority;
        public Game1Form()
        {
            InitializeComponent();
            idLabel.Content = "ID:" + ((Player)allPlayers[0]).id.ToString();
            nameLabel.Content = ((Player)allPlayers[0]).firstName + " " + ((Player)allPlayers[0]).lastName;
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            if (counter == GameIO.numPlayers)
            {
                return;
            }
            playerVotes[counter] = true;
            numYes++;
            counter++;
            if (counter < GameIO.numPlayers)
            {
                idLabel.Content = "ID:" + ((Player)allPlayers[counter]).id.ToString();
                nameLabel.Content = ((Player)allPlayers[counter]).firstName + " " + ((Player)allPlayers[counter]).lastName;
            }
            else
            {
                idLabel.Content = "";
                nameLabel.Content = "";
                tallyLabel.Content = "Ready to Tally";
            }
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            if (counter == GameIO.numPlayers)
            {
                return;
            }
            playerVotes[counter] = false;
            numNo++;
            counter++;
            if (counter < GameIO.numPlayers)
            {
                idLabel.Content = "ID:" + ((Player)allPlayers[counter]).id.ToString();
                nameLabel.Content = ((Player)allPlayers[counter]).firstName + " " + ((Player)allPlayers[counter]).lastName;
            }
            else
            {
                idLabel.Content = "";
                nameLabel.Content = "";
                tallyLabel.Content = "Ready to Tally";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (counter != GameIO.numPlayers)
            {
                return;
            }

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

            /* 
            * minority 0 = NO is minority 
            * minority 1 = YES is minorty
            * minority 2 = TIE
            */
            
            if (numYes > numNo)
            {
                minority = 0;
            }
            else if (numYes < numNo)
            {
                minority = 1;
            }
            else
            {
                minority = 2;
            }

            if (numYes == GameIO.numPlayers || numNo == GameIO.numPlayers)
            {
                minority = 2;
            }

            if (minority == 0)
            {
                switch (numNo)
                {
                    case 1:
                    case 2:
                        numVaccines = 3;
                        break;
                    case 3:
                        numVaccines = 2;
                        break;
                    case 4:
                        numVaccines = 1;
                        break;
                    default:
                        numVaccines = 0;
                        break; 
                }
            }
            else if (minority == 1)
            {
                switch (numYes)
                {
                    case 1:
                    case 2:
                        numVaccines = 3;
                        break;
                    case 3:
                        numVaccines = 2;
                        break;
                    case 4:
                        numVaccines = 1;
                        break;
                    default:
                        numVaccines = 0;
                        break;
                }
            }

            Properties.Settings.Default.hasPlayedMinorityGame = true;
            Properties.Settings.Default.Save();
            MinorityGameTransition page = new MinorityGameTransition();
            this.Content = page;
        }

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 0)
            {
                return;
            }
            counter--;
            idLabel.Content = "ID:" + ((Player)allPlayers[counter]).id.ToString();
            nameLabel.Content = ((Player)allPlayers[counter]).firstName + " " + ((Player)allPlayers[counter]).lastName;
            if (playerVotes[counter] == true)
            {
                numYes--;
            }
            else
            {
                numNo--;
            }
            if (counter == GameIO.numPlayers - 1)
            {
                tallyLabel.Content = "";
            }
        }
    }
}
