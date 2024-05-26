using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_15_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Запуск Thread с методом.
            ThreadStart threadStart = new ThreadStart(ThreadMethod);
            Thread thread = new Thread(threadStart);
            thread.Start();

            // 2. Запуск Thread с методом, принимающим параметр.
            ParameterizedThreadStart paramThreadStart = new ParameterizedThreadStart(ParamThreadMethod);
            Thread paramThread = new Thread(paramThreadStart);
            paramThread.Start("768467");

            // 3. Работа в Thread основного метода.
            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "Thread from main method";
            for(int i = 0; i < 50; i ++) {
                Console.WriteLine($"MethodMessage: 12345 /// ThreadName: {currentThread.Name}");
                Thread.Sleep(20);
            }
            Console.WriteLine($"{currentThread.Name} закончился");

            Console.ReadKey();
        }

        public static void ThreadMethod()
        {
            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "Thread from method";

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"MethodMessage: 12345 /// ThreadName: {currentThread.Name}");
                Thread.Sleep(10);
            }
            Console.WriteLine($"Thread {currentThread.Name} закончился");
        }

        public static void ParamThreadMethod(object o)
        {
            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "Parameterized thread from method";

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"MethodMessage: {o as string} /// ThreadName: {currentThread.Name}");
                Thread.Sleep(30);
            }
            Console.WriteLine($"Thread {currentThread.Name} закончился");
        }
    }
}
