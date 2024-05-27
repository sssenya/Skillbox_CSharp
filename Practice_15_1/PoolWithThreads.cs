using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_15_1 {
    internal class PoolWithThreads {
        public PoolWithThreads() {
            WaitCallback wcb1 = new WaitCallback(ThreadTask1);
            WaitCallback wcb2 = new WaitCallback(ThreadTask2);
            WaitCallback wcb3 = new WaitCallback(ThreadTask3);

            ThreadPool.QueueUserWorkItem(wcb1);
            ThreadPool.QueueUserWorkItem(wcb2);
            ThreadPool.QueueUserWorkItem(wcb3);
        }

        public static void ThreadTask1(object o) {
            for(int i = 0; i < 50; i++) {
                Console.WriteLine("_1_");
                Thread.Sleep(20);
            }
            
        }

        public static void ThreadTask2(object o) {
            for(int i = 0; i < 50; i++) {
                Console.WriteLine("_2_");
                Thread.Sleep(20);
            }
        }

        public static void ThreadTask3(object o) {
            for(int i = 0; i < 50; i++) {
                Console.WriteLine("_3_");
                Thread.Sleep(20);
            }
        }
    }
}
