using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LWCSummerRetreat17
{
    /// <summary>
    /// Interaction logic for DataForm.xaml
    /// </summary>
    public partial class DataForm : Window
    {
        ArrayList allPlayers = new ArrayList();
        public DataForm()
        {
            InitializeComponent();
            allPlayers = GameIO.load(0); 
        }


        private void DataForm_Load(object sender, EventArgs e)
        {

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
                    e.Handled = true;
                    idError.Content = "";
                    Player player = (Player)allPlayers[id - 1]; 
                    firstNameDynamic.Content = player.firstName;
                    lastNameDynamic.Content = player.lastName;
                    balanceDynamic.Content = player.balance.ToString("F");
                }
                else
                {
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
                balanceDynamic.Content = player.balance.ToString("F");
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