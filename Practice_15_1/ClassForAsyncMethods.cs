using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_15_1 {
    internal class ClassForAsyncMethods {
        public async void Main() {
            MethodNonAsync();
            await MethodAwaitAsync();
            MethodAsync1();
            MethodAsync2();
        }

        public void MethodNonAsync() {
            ThreadInfo.PrintThreadInfo("MethodNonAsync", "+", 10);
        }

        public async Task MethodAwaitAsync() {
            await Task.Run(() => ThreadInfo.PrintThreadInfo("MethodAwaitAsync", "++", 10));
        }

        public async Task MethodAsync1() {
            Task.Run(() => ThreadInfo.PrintThreadInfo("MethodAsync1", "+++", 20));
        }

        public async Task MethodAsync2() {
            Task.Run(() => ThreadInfo.PrintThreadInfo("MethodAsync2", "++++", 30));
        }
    }
}
