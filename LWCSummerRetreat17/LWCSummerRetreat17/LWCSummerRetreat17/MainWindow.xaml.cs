using System.Windows;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Forms;

namespace LWCSummerRetreat17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void game1_Click_1(object sender, RoutedEventArgs e)
        {
            Game1Form game1Form = new Game1Form();
            game1Form.Show();
        }

        private void game2_Click_1(object sender, RoutedEventArgs e)
        {
            Game2Form game2Form = new Game2Form();
            game2Form.Show();
        }

        private void game3_Click_1(object sender, RoutedEventArgs e)
        {
            Game3Form game3Form = new Game3Form();
            game3Form.Show();
        }

        private void data_Click_1(object sender, RoutedEventArgs e)
        {
            DataForm dataForm = new DataForm();
            dataForm.Show();
        }

        private void transfer_Click_1(object sender, RoutedEventArgs e)
        {
            TransferForm transferForm = new TransferForm();
            transferForm.Show();
        }

        private void allPlayers_Click_1(object sender, RoutedEventArgs e)
        {
            AllPlayerDataForm allPlayerDataForm = new AllPlayerDataForm();
            allPlayerDataForm.Show();
        }

       
    }
}