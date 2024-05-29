using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_15_1 {
    internal class ClassForThreadPool {
        public void Main() {
            WaitCallback wcb1 = new WaitCallback(ThreadPoolTask1);
            WaitCallback wcb2 = new WaitCallback(ThreadPoolTask2);
            WaitCallback wcb3 = new WaitCallback(ThreadPoolTask3);

            ThreadPool.QueueUserWorkItem(wcb1);
            ThreadPool.QueueUserWorkItem(wcb2);
            ThreadPool.QueueUserWorkItem(wcb3);
        }

        public static void ThreadPoolTask1(object o) {
            ThreadInfo.PrintThreadInfo("ThreadPoolTask1", "+", 10);
        }

        public static void ThreadPoolTask2(object o) {
            ThreadInfo.PrintThreadInfo("ThreadPoolTask2", "++", 30);
        }

        public static void ThreadPoolTask3(object o) {
            ThreadInfo.PrintThreadInfo("ThreadPoolTask3", "+++", 50);
        }
    }
}
