using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите предложение:");
            string inputPhrase = Console.ReadLine();

            string result = ReversWords(inputPhrase);

            Console.WriteLine();
            Console.WriteLine("Результат:");
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static string ReversWords(string inputPhrase)
        {
            string[] words = Reverse(inputPhrase);

            string resultString = "";

            for (int i = words.Length - 1; i >= 0; i--)
            {
                resultString += words[i] + " ";
            }

            return resultString;
        }

        static string[] Reverse(string text)
        {
            return text.Split(' ');
        }
    }
}
