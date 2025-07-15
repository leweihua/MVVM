using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData
{
    public partial class User : ObservableObject
    {
        [ObservableProperty]
        public string? _name;

        [ObservableProperty]
        public string? _email;

        [ObservableProperty]
        public string? _password;

    }
}
