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
    /// Interaction logic for MusicalChairsEliminationPage.xaml
    /// </summary>
    public partial class MusicalChairsEliminationPage : Page
    {

        CPass[] cpasses = CPass.createCPasses();
        public MusicalChairsEliminationPage()
        {
            InitializeComponent();
            minoritygametitle.Content = "-CPass Elimination Round " + (GameIO.game2Round - 1).ToString() + "-";
        }

        private void eliminateButton_Click(object sender, RoutedEventArgs e)
        {
            if (isValidID(cpassIDDynamic.Text))
            {
                int cpid = int.Parse(cpassIDDynamic.Text);
                if (cpasses[cpid - 1].isElim == true)
                {
                    errorLabel.Content = "CPass ID:" + cpid.ToString() + " has ALREADY been eliminated.";
                    successLabel.Content = "";
                }
                else
                {
                    cpasses[cpid - 1].isElim = true;
                    errorLabel.Content = "";
                    successLabel.Content = "CPass ID:" + cpid.ToString() + " has been eliminated.";
                }
            }
            else
            {
                errorLabel.Content = "Please enter valid CPass ID.";
                successLabel.Content = "";
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            CPass.saveCPasses(cpasses);
            Game2Form form = new Game2Form();
            Game2Form win = (Game2Form)Window.GetWindow(this);
            win.Close();
            form.Show();
        }

        private Boolean isValidID(string id)
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
