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
    /// Interaction logic for MinorityGameTransition.xaml
    /// </summary>
    public partial class MinorityGameTransition : Page
    {
        public MinorityGameTransition()
        {
            InitializeComponent();
        }

        private void resultButton_Click(object sender, RoutedEventArgs e)
        {
            MinorityTally page = new MinorityTally();
            Game1Form win = (Game1Form)Window.GetWindow(this);
            page.yesCount.Content = win.numYes;
            page.noCount.Content = win.numNo;
            win.Content = page;
        }
    }
}
