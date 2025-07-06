using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData
{
    public static class UserManager
    {
        public static ObservableCollection<User> DataBaseUsers = new ObservableCollection<User>()
     {
         new User() { name = "小王", email = "123@qq.com" },
         new User() { name = "小红", email = "456@qq.com" },
         new User() { name = "小五", email = "789@qq.com" }
     };

        public static ObservableCollection<User> GetUsers()
        {
            return DataBaseUsers;
        }

        public static void AddUser(User user)
        {
            DataBaseUsers.Add(user);
        }
    }
}
