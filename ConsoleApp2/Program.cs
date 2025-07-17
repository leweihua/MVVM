namespace ConsoleApp2
{
    internal class Program
    {
        // 委托
        public delegate void MyDelegate(string message);
        // 事件
        public event MyDelegate? MyEvent;

        // 泛型方法
        public T GenericMethod<T>(T param)
        {
            return param;
        }

        void ShowMyMess(string message)
        {
            Console.WriteLine($"My {message}");
        }
        void ShowOtherMess(string message)
        {
            Console.WriteLine($"Other {message}");
        }




        static void Main(string[] args)
        {
            // 创建 Program 类的实例以调用非静态方法
            Program programInstance = new Program();
            int var1 = programInstance.GenericMethod<int>(10);
            //
            MyDelegate md = programInstance.ShowMyMess;
            md("nihao");
            //
            programInstance.MyEvent += programInstance.ShowOtherMess;
            programInstance.MyEvent += programInstance.ShowMyMess;
            programInstance.MyEvent?.Invoke("ABC");
        }
    }
}
