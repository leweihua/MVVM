﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class MyCustomException : Exception
    {
        public MyCustomException(string msg) : base(msg) { }
    }
}
