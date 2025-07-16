using System.Reflection;
using static MyApp.MyComponent;

namespace MyApp
{
    internal class Program
    {
        public static T GetFirst<T>(T[] array)
        {
            return array[0];
        }

        public static int Add(int x, int y) => x + y;
        static void Main(string[] args)
        {
            Console.WriteLine(GetFirst<int>(new int[] { 1, 2, 3, 4 }));
            Type t = typeof(MyComponent);
            object[] attrs = t.GetCustomAttributes(typeof(AuthorAttribute), false);

            foreach (AuthorAttribute attr in attrs)
            {
                Console.WriteLine($"作者: {attr.Name}");
            }

#if DEBUG
            Console.WriteLine("调试模式");
#else
        Console.WriteLine("发布模式");
#endif

            #region 用户信息处理
            // 此区域用于处理用户信息
            #endregion

#pragma warning disable CS0168  // 忽略未使用变量警告
            int x;
#pragma warning restore CS0168

            Type type = typeof(string);
            MethodInfo[] methods = type.GetMethods();

            //foreach (var m in methods)
            //{
            //    Console.WriteLine(m.Name);
            //}

            Incrementer incrementer = new Incrementer();
            Dozens dozens = new Dozens(incrementer);
            // 通知订阅者
            incrementer.DoCount();
            Console.WriteLine($"Dozens counted: {dozens.DozensCount}");



            Box<int> intBox = new Box<int> { Value = 10 };
            Box<string> strBox = new Box<string> { Value = "Hello" };






            Point p = new Point(3, 4);
            p.Print();

            Operation op = Add;
            Console.WriteLine(op(2, 3)); // 输出 5

            Operation multiply = (a, b) => a * b;
            Console.WriteLine(multiply(4, 5)); // 输出 20

            //Console.WriteLine("Hello, World!");
            try
            {
                //int x = 0;
                //int y = 5 / x;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }

    public delegate int Operation(int a, int b);

    public class Box<T>
    {
        public T Value;
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorAttribute : Attribute
    {
        public string Name { get; }
        public AuthorAttribute(string name) => Name = name;
    }

    [Author("乐炜桦")]
    public class MyComponent
    {
        enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday }

        Days today = Days.Tuesday;

        // 类体
        public struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Print() => Console.WriteLine($"({X}, {Y})");
        }

    }


    class Incrementer
    {
        // 使用系统定义的EventHandler委托
        public event EventHandler CountedADozen;
        public void DoCount()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                {
                    // 触发事件
                    CountedADozen(this, EventArgs.Empty);
                }
            }
        }
    }

    class Dozens
    {
        public int DozensCount { get; private set; }
        public Dozens(Incrementer incrementer)
        {
            DozensCount = 0;
            incrementer.CountedADozen += IncrementerCountedADozen;
        }
        // 事件处理程序的签名必须委托的签名匹配
        private void IncrementerCountedADozen(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Dozen counted!");
            DozensCount++;
        }
    }
}


