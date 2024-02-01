using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8_2_Collections
{
    internal class Program
    {
        private static Dictionary<int, string> subscribers = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите ФИО:");
                string fioInput = Console.ReadLine();
                Console.WriteLine("Введите номер телефона:");
                string phoneInput = Console.ReadLine();
                int.TryParse(phoneInput, out var phoneNumber);

                if(string.IsNullOrEmpty(fioInput) || string.IsNullOrEmpty(phoneInput))
                {
                    break;
                }
                else
                {
                    subscribers.Add(phoneNumber, fioInput);
                }
            }

            while (true)
            {
                Console.WriteLine("Для поиска введите номер телефона:");
                string phoneInput = Console.ReadLine();
                int.TryParse(phoneInput, out var phoneNumber);

                if (string.IsNullOrEmpty(phoneInput))
                {
                    break;
                }
                else
                {
                    FindSubscriber(phoneNumber);
                }
            }
        }

        private static void FindSubscriber(int phoneNumber)
        {
            if (subscribers.TryGetValue(phoneNumber, out string subscriber))
            {
                Console.WriteLine(subscriber);
            }
            else
            {
                Console.WriteLine("Пользователь не найден");
            }
        }
    }
}
