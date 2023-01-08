using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("min started ");
            someMethod();
            Console.WriteLine("main ended ");
            Console.ReadLine();
        }
      public static async void  someMethod()
        {
            Console.WriteLine("some started ");
            await Wait();
            Console.WriteLine("some ended ");
        }
        public static async Task Wait()
        {
            Thread.Sleep(5000);
            Console.WriteLine("5 seconds delay ");
        }
    }
}
