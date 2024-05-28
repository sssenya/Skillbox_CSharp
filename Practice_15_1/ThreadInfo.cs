using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_15_1 {
    internal class ThreadInfo {
        public static void PrintThreadInfo(string methodName, 
                                           string methodMessage,
                                           int sleepTime) {
            Thread currentThread = Thread.CurrentThread;
            int hashCode = currentThread.GetHashCode();

            Console.WriteLine($">>>>>Метод \"{methodName}\" в Thread ID {hashCode} начался\">>>>>");

            for(int i = 0; i < 10; i++) {

                Console.WriteLine($"{methodMessage} /// ThreadID: {hashCode}");
                Thread.Sleep(sleepTime);
            }

            Console.WriteLine($"<<<<<Метод \"{methodName}\" в Thread ID {hashCode} закончился<<<<<");
        }
    }
}
