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
                int cardValue = 0;
                while (cardValue == 0)
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
                            cardValue  = int.Parse(cardUserInput);
                            break;

                        case "J":
                        case "Q":
                        case "K":
                        case "T":
                            cardValue = 10;
                            break;
                        default:
                            Console.WriteLine("Карты с таким номиналом не существует! Попробуйте еще раз.");
                            break;
                    }
                }
                sum += cardValue;
            }
            Console.WriteLine($"Сумма ваших карт {sum}");
            Console.ReadKey();

        }
    }
}
