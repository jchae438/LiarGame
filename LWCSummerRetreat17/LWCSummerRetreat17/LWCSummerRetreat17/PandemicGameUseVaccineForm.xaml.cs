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
    /// Interaction logic for PandemicGameUseVaccineForm.xaml
    /// </summary>
    public partial class PandemicGameUseVaccineForm : Window
    {
        ArrayList allPlayers = GameIO.load(0);
        public PandemicGameUseVaccineForm()
        {
            InitializeComponent();
        }

        //enter key pressed
        private string reqID;
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                TextBox temp = (TextBox)sender;
                reqID = temp.Text;
                if (isValidID(reqID))
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                TextBox temp = (TextBox)sender;
                reqID = temp.Text;

                if (isValidID(reqID))
                {
                    int id = int.Parse(reqID);
                    if (((Game1)PandemicGame.allPlayersAsGame1[id - 1]).vaccines <= 0)
                    {
                        vaccineSuccessLabel.Content = "";
                        idError.Content = "Vaccination failed: Insufficient number of vaccines.";
                        return;
                    }
                    if (((Game1)PandemicGame.allPlayersAsGame1[id - 1]).isInfected == false)
                    {
                        vaccineSuccessLabel.Content = "";
                        idError.Content = "Vaccination failed: Player is not infected.";
                        return;
                    }
                    ((Game1)PandemicGame.allPlayersAsGame1[id - 1]).isInfected = false;
                    ((Game1)PandemicGame.allPlayersAsGame1[id - 1]).vaccines--;
                    e.Handled = true;
                    idError.Content = "";
                    vaccineSuccessLabel.Content = "Vaccination Successful for ID:" + id.ToString();

                    Player player = (Player)allPlayers[id - 1];
                    firstNameDynamic.Content = player.firstName;
                    lastNameDynamic.Content = player.lastName;
                    if (((Game1)PandemicGame.allPlayersAsGame1[id - 1]).isInfected == true)
                    {
                        balanceDynamic.Content = "Infected";
                    }
                    else
                    {
                        balanceDynamic.Content = "Normal";
                    }
                    vaccineDynamic.Content = ((Game1)PandemicGame.allPlayersAsGame1[id - 1]).vaccines.ToString();
                }
                else
                {
                    vaccineSuccessLabel.Content = "";
                    idError.Content = "Invalid ID. Please enter a valid ID";
                    return;
                }

            }
        }

        private void idOK_Click(object sender, EventArgs e)
        {
            reqID = idTextBox.Text;
            if (isValidID(reqID))
            {
                int id = int.Parse(reqID);
                idError.Content = "";
                Player player = (Player)allPlayers[id - 1];
                firstNameDynamic.Content = player.firstName;
                lastNameDynamic.Content = player.lastName;
                balanceDynamic.Content = ((Game1)PandemicGame.allPlayersAsGame1[id - 1]).isInfected.ToString();
                vaccineDynamic.Content = ((Game1)PandemicGame.allPlayersAsGame1[id - 1]).vaccines.ToString();
            }
            else
            {
                idError.Content = "Invalid ID. Please enter a valid ID";
                return;
            }
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
