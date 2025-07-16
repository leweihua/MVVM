using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAsync
{
    internal class TimeRun
    {
        int TimesCalled = 0;
        void DisPlay(object obj)
        {
            Console.WriteLine($"{(string)obj} {++TimesCalled}");
        }
    }
}
