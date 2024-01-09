using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите количество чисел:");
            string userMaxInput = Console.ReadLine();
            int maxNumber = int.Parse(userMaxInput);

            var random = new Random();
            int hiddenNumber = random.Next(maxNumber + 1);

            while (true)
            {
                Console.WriteLine("Введите число");
                string userInput = Console.ReadLine();
                if (userInput.Length == 0)
                {
                    Console.WriteLine($"Игра завершена! Загаданное число {hiddenNumber}");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    int userNumber = int.Parse(userInput);
                    if (userNumber == hiddenNumber) 
                    {
                        Console.WriteLine("Вы угадали число!");
                        Console.ReadKey();
                        break;
                    }
                    else if(userNumber < hiddenNumber)
                    {
                        Console.WriteLine("Загаданное число больше.");
                    }
                    else
                    {
                        Console.WriteLine("Загаданное число меньше.");
                    }
                }
            }
        }
    }
}
