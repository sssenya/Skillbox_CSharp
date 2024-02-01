using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();
            string userInput;

            do
            {
                Console.WriteLine("Введите целое число:");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out var userInt);

                if (set.Add(userInt))
                {
                    Console.WriteLine("Число добавлено!");
                }
                else
                {
                    Console.WriteLine("Число уже присутствует в коллекции!");
                }
            }
            while (!string.IsNullOrEmpty(userInput));            
        }
    }
}
