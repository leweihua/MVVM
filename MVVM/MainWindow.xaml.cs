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
//using UserData;

namespace MVVM
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dataGrid1.ItemsSource = UserManager.GetUsers();
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            //User user=new User();
            //user.name=nameTextBox.Text;
            //user.email=emailTextBox.Text;
            //UserManager.AddUser(user);
            //MessageBox.Show("成功添加用户！");
        }
    }


}