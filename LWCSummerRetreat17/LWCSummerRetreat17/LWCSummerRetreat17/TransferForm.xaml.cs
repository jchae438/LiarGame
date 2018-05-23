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
    /// Interaction logic for TransferForm.xaml
    /// </summary>
    public partial class TransferForm : Window
    {
        public TransferForm()
        {
            InitializeComponent();
        }

        private string srcIDString;
        private string destIDString;
        private string transferValueString;
        ArrayList allPlayers = GameIO.load(0);
        private void confirmTransfer_Click_1(object sender, RoutedEventArgs e)
        {
            srcIDString = srcIDTB.Text;
            destIDString = destIDTB.Text;
            transferValueString = transferValTB.Text;
            double transferValue;

            if (isValidID(srcIDString))
            {
                if (isValidID(destIDString))
                {
                    if (double.TryParse(transferValueString, out transferValue))
                    {
                        int srcID = int.Parse(srcIDString);
                        int destID = int.Parse(destIDString);
                        if(srcID == destID)
                        {
                            //transfer failed 
                            transferSuccessLabel.Content = "";
                            errorLabel.Content = "Please enter two distinct player ID's.";
                        }
                        transferValue = Math.Round(transferValue, 2);
                        if (Player.transferCurrency(srcID, destID, transferValue) == false)
                        {
                            //transfer failed 
                            transferSuccessLabel.Content = "";
                            errorLabel.Content = "Transfer failed due to insufficient funds. Please try again.";
                        }
                        else
                        {
                            string output = "";
                            if(srcID == 0)
                            {
                                output = "Transfer from Bank to ID:" + ((Player)allPlayers[destID - 1]).id.ToString() + " Successful";
                            }
                            else if (destID == 0)
                            {
                                output = "Transfer from ID:" + ((Player)allPlayers[srcID - 1]).id.ToString() + " to Bank Successful";
                            }
                            else
                            {
                                output = "Transfer from ID:" + ((Player)allPlayers[srcID - 1]).id.ToString() + " to ID:" + ((Player)allPlayers[destID - 1]).id.ToString() + " Successful";
                            }
                            transferSuccessLabel.Content = output;
                            errorLabel.Content = "";
                        }
                    }
                    else
                    {
                        transferSuccessLabel.Content = "";
                        errorLabel.Content = "Please enter a valid transfer value.";
                        return;
                    }
                }
                else
                {
                    transferSuccessLabel.Content = "";
                    errorLabel.Content = "Please enter a valid \"Their ID\".";
                    return;
                }
            }
            else
            {
                transferSuccessLabel.Content = "";
                errorLabel.Content = "Please enter a valid \"My ID\".";
                return;
            }

        }

        private void transferValTB_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                srcIDString = srcIDTB.Text;
                destIDString = destIDTB.Text;
                transferValueString = transferValTB.Text;
                double transferValue;

                if (isValidID(srcIDString) && isValidID(destIDString) && double.TryParse(transferValueString, out transferValue))
                {
                    int srcID = int.Parse(srcIDString);
                    int destID = int.Parse(destIDString);
                    transferValue = Math.Round(transferValue, 2);
                    e.Handled = true;
                }
            }
        }

        private void transferValTB_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                srcIDString = srcIDTB.Text;
                destIDString = destIDTB.Text;
                transferValueString = transferValTB.Text;
                double transferValue;

                if (isValidID(srcIDString))
                {
                    if (isValidID(destIDString))
                    {
                        if (double.TryParse(transferValueString, out transferValue))
                        {
                            int srcID = int.Parse(srcIDString);
                            int destID = int.Parse(destIDString);
                            if (srcID == destID)
                            {
                                //transfer failed 
                                transferSuccessLabel.Content = "";
                                errorLabel.Content = "Please enter two distinct player ID's.";
                            }
                            transferValue = Math.Round(transferValue, 2);
                            if (Player.transferCurrency(srcID, destID, transferValue) == false)
                            {
                                //transfer failed 
                                e.Handled = true;
                                transferSuccessLabel.Content = "";
                                errorLabel.Content = "Transfer failed due to insufficient funds. Please try again.";
                            }
                            else
                            {
                                string output = "";
                                if (srcID == 0)
                                {
                                    output = "Transfer from Bank to ID:" + ((Player)allPlayers[destID - 1]).id.ToString() + " Successful";
                                }
                                else if (destID == 0)
                                {
                                    output = "Transfer from ID:" + ((Player)allPlayers[srcID - 1]).id.ToString() + " to Bank Successful";
                                }
                                else
                                {
                                    output = "Transfer from ID:" + ((Player)allPlayers[srcID - 1]).id.ToString() + " to ID:" + ((Player)allPlayers[destID - 1]).id.ToString() + " Successful";
                                }
                                transferSuccessLabel.Content = output;
                                errorLabel.Content = "";
                            }
                        }
                        else
                        {
                            e.Handled = false;
                            transferSuccessLabel.Content = "";
                            errorLabel.Content = "Please enter a valid transfer value.";
                            return;
                        }
                    }
                    else
                    {
                        e.Handled = false;
                        transferSuccessLabel.Content = "";
                        errorLabel.Content = "Please enter a valid \"Their ID\".";
                        return;
                    }
                }
                else
                {
                    e.Handled = false;
                    errorLabel.Content = "Please enter a valid \"My ID\".";
                    return;
                }
            }
        }

        private Boolean isValidID(string id)
        {
            int n;
            if (int.TryParse(id, out n))
            {
                if (n >= 0 && n <= GameIO.numPlayers)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
