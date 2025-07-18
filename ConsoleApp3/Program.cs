namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Car myCar = new Car();
            myCar.Move(15.3);
            Console.ReadLine();
            MyInterface vehicle = new Car();
            vehicle.Move(100); // 使用接口类型引用调用方法
            int a = 0, b = 1, c;
            Console.WriteLine(SayHi(in a, ref b, out c));
            Func<string> callString = () => "NIHAO";
            Func<int, int, int> myFunc = (x, y) => x + y;
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine($"{callString} + {myFunc(1, 2)} + {add(5, 6)}");

        }

        public static int SayHi(in int x, ref int y, out int z)
        {
            y += 1;
            return z = x + y;
        }

        public T AddAll<T>(T a, T b) where T : struct
        {
            dynamic da = a;
            dynamic db = b;
            return da + db;
        }

        public void Print<T>(T item)
        {
            Console.WriteLine(item);
        }

        public class Car : MyInterface, Interface1
        {
            public void Move(double distance)
            {
                Console.WriteLine(distance);
            }

            void MyInterface.Show() => Console.WriteLine("Shared Show MyInterface");

            void Interface1.Show() => Console.WriteLine("Shared Show Interface1");
        }
    }
}
