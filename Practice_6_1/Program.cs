using System;
using System.IO;
using System.Text;

namespace Practice_6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string filePath = projectDirectory + "\\Workers\\workers_list.txt";

            int number = ReadUserCommand();

            switch (number)
            {
                case 1:
                    PrintAllItemsByStreamReader(filePath);
                    break;
                case 2:
                    string workerInfo = ReadWorkerInfo();
                    AddNewItemByStreamWriter(filePath, workerInfo);
                    break;
                default:
                    Console.WriteLine("Команда введена не верно");
                    break;
            }

            Console.ReadKey();
        }

        static int ReadUserCommand()
        {
            Console.WriteLine("Здравствуйте! Введите команду:");
            Console.WriteLine("1 - вывод данных на экран");
            Console.WriteLine("2 - добавить новые данные");

            string userCommand = Console.ReadLine();
            int.TryParse(userCommand, out var number);
            Console.WriteLine();

            return number;
        }

        static string ReadWorkerInfo()
        {
            string[] lines = new string[7];
            Console.Write("ID: ");
            lines[0] = Console.ReadLine();
            Console.Write("Дата и время добавления записи: ");
            lines[1] = Console.ReadLine();
            Console.Write("Ф. И. О.: ");
            lines[2] = Console.ReadLine();
            Console.Write("Возраст: ");
            lines[3] = Console.ReadLine();
            Console.Write("Рост: ");
            lines[4] = Console.ReadLine();
            Console.Write("Дата рождения: ");
            lines[5] = Console.ReadLine();
            Console.Write("Место рождения: ");
            lines[6] = Console.ReadLine();

            return string.Join("#", lines);
        }

        static void AddNewItemByStreamWriter(string filePath, string itemText)
        {
            using (StreamWriter stream = new StreamWriter(filePath, true))
            {
                stream.WriteLine(itemText);
            }
        }

        static void PrintAllItemsByStreamReader(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader stream = new StreamReader(filePath))
                {
                    while (!stream.EndOfStream)
                    {
                        string[] words = stream.ReadLine().Split('#');
                        foreach (string word in words)
                        {
                            Console.WriteLine(word);
                        }
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл отсутствует!");
            }
        }
    }
}
