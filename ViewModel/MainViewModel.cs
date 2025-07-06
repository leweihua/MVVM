using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using UserData;
using static System.Net.Mime.MediaTypeNames;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<User> Users { get; set; }

    [ObservableProperty]
    private string? _name;

    [ObservableProperty]
    private string? _email;

    public MainViewModel()
    {
        Users = UserManager.GetUsers();
    }

    [RelayCommand]
    private void Test(object obj)
    {
        //Name = "小1";
        //Email = "111@qq.com";
        // 测试VideModel改变Model里面的数据以后，Model发出Notification更新属性，而后再由ViewModel通知View
        Users[0].Name = "小1";
        Users[0].Email = "111@qq.com";
    }

    [RelayCommand]
    private void AddUser(object obj)
    {
        User user = new User();
        user.Name = Name;
        user.Email = Email;
        UserManager.AddUser(user);
    }
}