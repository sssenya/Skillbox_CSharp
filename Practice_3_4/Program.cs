using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите длину последовательности:");
            string userLengthInput = Console.ReadLine();
            int lengthOfSequence = int.Parse(userLengthInput);

            int minValue = int.MaxValue;

            for (int i = 0; i < lengthOfSequence; i++)
            {
                Console.WriteLine($"Введите {i+1}-й элемент последовательности:");
                string userInput = Console.ReadLine();
                int userNumber = int.Parse(userInput);

                if (userNumber < minValue)
                {
                    minValue = userNumber;
                }
            }

            Console.WriteLine($"Наименьший элемент в вашей последовательности: {minValue}");
            Console.ReadKey();
        }
    }
}
