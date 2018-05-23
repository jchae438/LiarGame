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
    /// Interaction logic for PandemicGameVictoryPointsAfterRepeat.xaml
    /// </summary>
    public partial class PandemicGameVictoryPointsAfterRepeat : Page
    {
        public PandemicGameVictoryPointsAfterRepeat()
        {
            InitializeComponent();
            string results = "";
            ArrayList allPlayers = GameIO.load(0);
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                Player temp = (Player)allPlayers[i];
                if (((Game1)PandemicGame.allPlayersAsGame1[i]).isInfected == true)
                {
                    results += "-" + temp.firstName + " " + temp.lastName + " - INFECTED - " + ((Game1)PandemicGame.allPlayersAsGame1[i]).vaccines + "\n";
                }
                else
                {
                    results += "-" + temp.firstName + " " + temp.lastName + " - NORMAL - " + ((Game1)PandemicGame.allPlayersAsGame1[i]).vaccines + "\n";
                }
            }
            listOfWinners.Content = results;
        }

        private void nextRoundButton_Click(object sender, RoutedEventArgs e)
        {
            Game1Form form = new Game1Form();
            Game1Form win = (Game1Form)Window.GetWindow(this);
            win.Close();
            form.Show();
        }

        private void endGameButton_Click(object sender, RoutedEventArgs e)
        {
            PandemicGameVictoryPointsAfterFinish form = new PandemicGameVictoryPointsAfterFinish();
            Game1Form win = (Game1Form)Window.GetWindow(this);
            win.Content = form;
        }
    }
}
