using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_15_1 {
    internal class ThreadInfo {
        public static void PrintThreadInfo(string threadName, 
                                           string threadMessage,
                                           int sleepTime) {
            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = threadName;

            for(int i = 0; i < 10; i++) {

                Console.WriteLine($"MethodMessage: {threadMessage} /// ThreadName: {currentThread.Name}");
                Thread.Sleep(sleepTime);
            }

            Console.WriteLine($"__________Thread \"{currentThread.Name}\" закончился__________");
        }
    }
}
