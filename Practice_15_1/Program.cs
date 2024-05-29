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
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($">>>>>Метод Main в потоке ID {currentThread.GetHashCode()} начался\">>>>>");

            Console.WriteLine("__________Создание потоков вручную__________");
            new ClassForThreads().Main();
            Console.WriteLine();

            Console.WriteLine("__________Создание потоков в пуле__________");
            new ClassForThreadPool().Main();
            Console.WriteLine();

            Console.WriteLine("__________Запуск Task__________");
            new ClassForTasks().Main();
            Console.WriteLine();

            Console.WriteLine("__________Запуск Async методов__________");
            new ClassForAsyncMethods().Main();
            Console.WriteLine();

            Console.ReadKey();
        }

    }
}
