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
    /// Interaction logic for MinorityTally.xaml
    /// </summary>
    public partial class MinorityTally : Page
    {
        public MinorityTally()
        {
            InitializeComponent();
        }

        private void pandemicButton_Click(object sender, RoutedEventArgs e)
        {
            if (Game1Form.minority == 2)
            {
                Game1Form win = (Game1Form)Window.GetWindow(this);
                Game1Form form = new Game1Form();
                win.Close();
                form.Show();
            }
            else
            {
                PandemicGame page = new PandemicGame();
                Game1Form win = (Game1Form)Window.GetWindow(this);
                win.Content = page;
            }
        }
    }
}
