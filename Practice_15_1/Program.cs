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
            ThreadStart threadStart = new ThreadStart(ThreadMethod);
            Thread thread = new Thread(threadStart);
            //Thread thread = new Thread(ThreadMethod);
            thread.Start();
            thread.Name = "threadName123";

            ParameterizedThreadStart paramThreadStart = new ParameterizedThreadStart(ParamThreadMethod);
            Thread paramThread = new Thread(paramThreadStart);
            paramThread.Start("xxxxx");

            for (int i = 0; i < 100; i ++) {
                Console.Write("text ");
                Thread.Sleep(10);
            }
            Console.WriteLine($"Thread {thread.Name} закончился");



            Console.ReadKey();
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("+ ");
                Thread.Sleep(10);
            }

            Thread currentThread = Thread.CurrentThread;
        }

        public static void ParamThreadMethod(object o)
        {
            
            for (int i = 0; i < 100; i++)
            {
                Console.Write(o as string);
                Thread.Sleep(10);
            }

            Thread currentThread = Thread.CurrentThread;
        }
    }
}
