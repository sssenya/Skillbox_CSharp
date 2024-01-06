using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число");
            string userInput = Console.ReadLine();
            int userInputParsed = int.Parse(userInput);

            if (userInputParsed % 2 == 0)
            {
                Console.WriteLine("Введено четное число");
            }
            else
            {
                Console.WriteLine("Введено нечетное число");
            }
            Console.ReadKey();
        }
    }
}
