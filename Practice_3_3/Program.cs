using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите число:");
            string userInput = Console.ReadLine();
            int userNumber = int.Parse(userInput);

            bool isPrimeNumber = true;
            int i = 2;

            while (i < userNumber - 1)
            {
                if(userNumber % i == 0)
                {
                    isPrimeNumber = false;
                    break;
                }
                i++;
            }

            if(isPrimeNumber)
            {
                Console.WriteLine("Введено простое число");
            }
            else
            {
                Console.WriteLine("Введено не простое число");
            }
            Console.ReadKey();
        }
    }
}
