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
    /// Interaction logic for Game2Form.xaml
    /// </summary>
    public partial class Game2Form : Window
    {

        private static ArrayList allPlayers = GameIO.load(0);
        CPass[] cpasses = CPass.createCPasses();
        public static ArrayList allPlayersAsGame2 = GameIO.load(2);

        public Game2Form()
        {
            InitializeComponent();
            minoritygametitle.Content = "-Musical Chairs Round " + GameIO.game2Round.ToString() + "-";
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                Game2 temp = (Game2)allPlayersAsGame2[i];
                temp.didSit = false;
            }
        }

        private void seatButton_Click(object sender, RoutedEventArgs e)
        {
            if (isValidID(playerID.Text))
            {
                if (isValidCPassID(cpassID.Text))
                {
                    if(cpassCode.Text != null)
                    {
                        //password is correct 
                        if(cpassCode.Text == cpasses[int.Parse(cpassID.Text) - 1].answer)
                        {
                            int cpid = int.Parse(cpassID.Text);
                            int playerid = int.Parse(playerID.Text);
                            Game2 temp = (Game2)allPlayersAsGame2[int.Parse(playerID.Text) - 1];
                            if(temp.isEliminated >= 2)
                            {
                                errorLabel.Content = "";
                                successLabel.Content = "Player has already been eliminated.";
                                return;
                            }
                            //person didn't sit in this last time
                            if (cpid != temp.prevCPassID)
                            {
                                //cpass is available
                                if (cpasses[int.Parse(cpassID.Text) - 1].isAvail == true && cpasses[int.Parse(cpassID.Text) - 1].isElim == false)
                                {
                                    if (temp.didSit == true)
                                    {
                                        errorLabel.Content = "Player ID:" + playerid.ToString() + " has already sat this round. ";
                                        successLabel.Content = "";
                                        return;
                                    }
                                    cpasses[int.Parse(cpassID.Text) - 1].isAvail = false;
                                    temp.currentCPassID = cpid;
                                    temp.prevCPassID = cpid;
                                    temp.didSit = true;
                                    errorLabel.Content = "";
                                    successLabel.Content = "Player ID: " + playerid.ToString() + " sat in CPass ID: " + cpid.ToString();
                                }
                                else if (cpasses[int.Parse(cpassID.Text) - 1].isElim == true)
                                {
                                    errorLabel.Content = "CPass " + cpid.ToString() + " has been eliminated.";
                                    successLabel.Content = "";
                                }
                                else
                                {
                                    errorLabel.Content = "CPass " + cpid.ToString() + " is not available this round.";
                                    successLabel.Content = "";
                                }
                            }
                            else
                            {
                                errorLabel.Content = "Player sat in this chair last round.";
                                successLabel.Content = "";
                            }
                        }
                        else
                        {
                            errorLabel.Content = "CPass code is incorrect.";
                            successLabel.Content = "";
                        }
                    }
                    else
                    {
                        errorLabel.Content = "Please enter a CPass code.";
                        successLabel.Content = "";
                    }
                }
                else
                {
                    errorLabel.Content = "Please enter valid CPass ID.";
                    successLabel.Content = "";
                }
            }
            else
            {
                errorLabel.Content = "Please enter valid player ID.";
                successLabel.Content = "";
            }
        }


        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            GameIO.game2Round++;
            CPass.saveCPasses(cpasses);
            GameIO.save(allPlayersAsGame2, 2);
            MusicalChairsResultsPage page = new MusicalChairsResultsPage();
            this.Content = page;
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

        private Boolean isValidCPassID(string id)
        {
            int n;
            if (int.TryParse(id, out n))
            {
                if (n >= 1 && n <= 20)
                {
                    return true;
                }
            }
            return false;
        }

        private void allPlayersData_Click_1(object sender, RoutedEventArgs e)
        {
            MusicalChairsAllPlayerDataWindow win = new MusicalChairsAllPlayerDataWindow();
            win.Show();
        }
    }
}
