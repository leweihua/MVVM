using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using UserData;
using static System.Net.Mime.MediaTypeNames;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<User> Users { get; set; }
    public ICommand AddUserCommand { get; set; }
    public ICommand TestCommand { get; set; }

    private string? _name;
    public string? Name
    {
        get { return _name; }
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
    private string? _email;
    public string? Email
    {
        get { return _email; }
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public MainViewModel()
    {
        Users = UserManager.GetUsers();
        AddUserCommand = new RelayCommand(AddUser, CanAddUser);
        TestCommand = new RelayCommand(Test, CanTest);

    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private bool CanTest(object obj)
    {
        return true;
    }

    private void Test(object obj)
    {
        //Name = "小1";
        //Email = "111@qq.com";
        // 测试VideModel改变Model里面的数据以后，Model发出Notification更新属性，而后再由ViewModel通知View
        Users[0].Name = "小1";
        Users[0].Email = "111@qq.com";
    }

    private bool CanAddUser(object obj)
    {
        return true;
    }
    private void AddUser(object obj)
    {
        User user = new User();
        user.name = Name;
        user.email = Email;
        UserManager.AddUser(user);
    }
}