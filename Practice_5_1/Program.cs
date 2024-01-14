using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите текст:");
            string userText = Console.ReadLine();

            string[] wordsFromText = SplitText(userText);
            PrintWords(wordsFromText);

            Console.ReadKey();
        }

        static string[] SplitText(string text)
        {
            return text.Split(' ');
        }

        static void PrintWords(string[] text)
        {
            foreach (string word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}
