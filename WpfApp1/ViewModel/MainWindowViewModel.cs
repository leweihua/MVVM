using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UserData;

namespace WpfApp1.ViewModel
{
    partial class MainWindowViewModel : ObservableObject
    {
        // 小驼峰的命名规则，即下面这玩意会生成一个Name，如果是frameVideo则生成FramVideo，大写的适合视图对应的
        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? password;

        public ObservableCollection<User> Users { get; set; }

        public MainWindowViewModel()
        {
            Users = UserManager.GetUsers();
        }

        [RelayCommand]
        private void Test(object obj)
        {
            //Name = "小1";
            //Email = "111@qq.com";
            // 测试VideModel改变Model里面的数据以后，Model发出Notification更新属性，而后再由ViewModel通知View
            //Users[0]._name = "小1";
            //Users[0]._email = "111@qq.com";
            //Users[0]._myPassword = "password";
            Users[0].Name = "小1";
            Users[0].Email = "111@qq.com";
            Users[0].Password = "password";
        }

        [RelayCommand]
        private void AddUser(object obj)
        {
            User user = new User();
            user.Name = Name;
            user.Email = Email;
            user.Password = Password;
            UserManager.AddUser(user);
        }
    }
}
