using System;
using System.Threading;

namespace DemoAsync
{
    internal class Program
    {
        int TimesCalled = 0;
        void DisPlay(object obj)
        {
            Console.WriteLine($"{(string)obj} {++TimesCalled}");
        }
        static void Main(string[] args)
        {
            //Program p = new Program();
            //Timer myTimer = new Timer(p.DisPlay, "Process Time Event", 2000, 1000);
            //Console.WriteLine("Start");
            int[] arrayInt = new int[15];
            Parallel.For(0, 15, i => Console.WriteLine($"The square of {i} is {i * i}"));

            Parallel.For(0, 15, i => arrayInt[i] = i * i);
            foreach (var item in arrayInt)
            {
                Console.WriteLine($"{item}");
            }

            string[] squares = new string[]{"We","hold","these","truths","to","be","self-evident",
"that", "all","men","are", "created", "equal"};
            Parallel.ForEach(squares, s => Console.WriteLine(string.Format($"\"{s}\" has {s.Length} letters")));



            Task.Run(() =>
            {
                Console.WriteLine("Task started");
                Thread.Sleep(5000); // Simulating a long-running task
                Console.WriteLine("Task completed");
            });

            int[] numbers = { 1, 2, 3, 4, 5 };
            var evens = numbers.Where(n => n % 2 == 0);
            foreach (var n in evens)
            {
                Console.WriteLine(n);
            }

            var names = new[] { "Alice", "Bob", "Charlie", "David" };
            var upperNames = names.Select(name => name.ToUpper()).OrderBy(name => name.Length);

            var grouped = names.GroupBy(name => name.Length);
            foreach (var group in grouped)
            {
                Console.WriteLine($"Names with {group.Key} letters:");
                foreach (var name in group)
                {
                    Console.WriteLine(name);
                }
            }
            Console.ReadLine();
        }
    }
}
