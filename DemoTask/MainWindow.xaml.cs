using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            btnExecute.IsEnabled = false;
            this.ShowMessage.Text = "Doing";
            await Task.Delay(5000); // Simulating a long-running task
            //Thread.Sleep(5000);
            this.ShowMessage.Text = "Done";
            btnExecute.IsEnabled = true;
        }
    }
}