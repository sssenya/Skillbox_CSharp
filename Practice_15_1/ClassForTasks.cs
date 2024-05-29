using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_15_1 {
    internal class ClassForTasks {
        public void Main() {
            Action action = new Action(TaskMethod1);
            Task task1 = new Task(action);
            task1.Start();

            Task task2 = Task.Factory.StartNew(TaskMethod2);

            // Вызов методов для ожидания окончания выполнения Task
            task1.Wait();
            task2.Wait();
        }

        public static void TaskMethod1() {
            Console.WriteLine($"_____Начался Task.ID={Task.CurrentId} " +
                $"в Thread ID {Thread.CurrentThread.GetHashCode()}");
            ThreadInfo.PrintThreadInfo("TaskMethod1", "++", 10);            
        }

        public static void TaskMethod2() {
            Console.WriteLine($"_____Начался Task.ID={Task.CurrentId} " +
                $"в Thread ID {Thread.CurrentThread.GetHashCode()}");
            ThreadInfo.PrintThreadInfo("TaskMethod2", "++++", 100);
        }
    }
}
