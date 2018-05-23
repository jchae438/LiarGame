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
    /// Interaction logic for MusicalChairsTokenPage.xaml
    /// </summary>
    public partial class MusicalChairsTokenPage : Page
    {
        public static double tokenValue = 0;
        public static double[] gameBalances = new double[GameIO.numPlayers];

        public MusicalChairsTokenPage()
        {
            InitializeComponent();
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                gameBalances[i] = 0;
            }
        }

        private void assignTokenValueButton_Click(object sender, RoutedEventArgs e)
        {
            if (isDouble(tokenValueBox.Text))
            {
                double.TryParse(tokenValueBox.Text, out tokenValue);
                errorLabel.Content = "";
                successLabel.Content = "Token value has been assigned.";
            }
            else
            {
                errorLabel.Content = "Please enter valid token value.";
                successLabel.Content = "";
            }
        }

        private void giveTokenButton_Click(object sender, RoutedEventArgs e)
        {
            if (isValidID(playerID.Text))
            {
                if (isNumber(numTokens.Text))
                {
                    int pid = int.Parse(playerID.Text);
                    int tokCount = int.Parse(numTokens.Text);
                    gameBalances[pid - 1] += tokenValue * tokCount;
                    errorLabel.Content = "";
                    successLabel.Content = "Player " + pid.ToString() + " has been given " + tokCount.ToString() + " tokens.";
                }
                else
                {
                    errorLabel.Content = "Please enter valid Player ID.";
                    successLabel.Content = "";
                }
            }
            else
            {
                errorLabel.Content = "Please enter valid token value.";
                successLabel.Content = "";
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            MusicalChairsTransferPointsPage page = new MusicalChairsTransferPointsPage();
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

        private Boolean isDouble(string id)
        {
            double n;
            if (double.TryParse(id, out n))
            {
                return true;
            }
            return false;
        }

        private Boolean isNumber(string id)
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
    }
}
