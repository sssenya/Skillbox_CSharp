using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_15_1 {
    internal class ClassForThreads {
        public void Main() {
            // 1. Запуск Thread с методом.
            ThreadStart threadStart = new ThreadStart(ThreadMethod);
            Thread thread = new Thread(threadStart);
            thread.Start();

            // 2. Запуск Thread с методом, принимающим параметр.
            ParameterizedThreadStart paramThreadStart = new ParameterizedThreadStart(ParamThreadMethod);
            Thread paramThread = new Thread(paramThreadStart);
            paramThread.Start("++");

            // 3. Работа в Thread основного метода.
            ThreadInfo.PrintThreadInfo("Thread from main method", "+", 20);
        }

        public static void ThreadMethod() {
            ThreadInfo.PrintThreadInfo("ThreadMethod", "+++", 10);
        }

        public static void ParamThreadMethod(object o) {
            ThreadInfo.PrintThreadInfo("ParamThreadMethod", o as string, 30);
        }
    }


}
