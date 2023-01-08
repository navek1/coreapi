using System;
using System.Threading;

namespace AsyncDelegate
{

    public delegate string MyDelegate(string message);
    class Program
    {


        static void Main(string[] args)
        {
            MyClass ob = new MyClass();
            MyDelegate del = new MyDelegate(ob.MyMethod);
            Console.WriteLine("Hello World!");
            var result= del.BeginInvoke("Result from MyMethod", new AsyncCallback(ob.myCallback), del);
            Console.WriteLine("Printed without wating for async to finish");
            Console.ReadLine();

        }


    }

   public  class MyClass
    {
        public string MyMethod(string msg)
        {
            Thread.Sleep(3000);
            return (msg);
        }

        public  void myCallback(IAsyncResult async)
        {
            MyDelegate del = (MyDelegate)async.AsyncState;
            string res =del.EndInvoke(async);
            Console.WriteLine("Task finished");
            Console.WriteLine(res);


        }
    }
}
