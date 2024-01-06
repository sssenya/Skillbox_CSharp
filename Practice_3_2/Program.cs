using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите количество у вас на руках:");
            string amountUserInput = Console.ReadLine();
            int cardsAmount = int.Parse(amountUserInput);

            int sum = 0;

            for (int i = 0; i < cardsAmount; i++)
            {
                Console.WriteLine("Введите номинал карты:");
                string cardUserInput = Console.ReadLine();

                switch (cardUserInput)
                {
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        sum += int.Parse(cardUserInput);
                        break;

                    case "J":
                    case "Q":
                    case "K":
                    case "T":
                        sum += 10;
                        break;
                }
            }
            Console.WriteLine($"Сумма ваших карт {sum}");
            Console.ReadKey();

        }
    }
}
