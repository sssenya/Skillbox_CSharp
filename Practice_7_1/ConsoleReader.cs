using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7_1
{
    internal class ConsoleReader
    {
        public int ReadIntInput()
        {
            string userCommandString = Console.ReadLine();
            int.TryParse(userCommandString, out int userCommand);
            Console.WriteLine();

            return userCommand;
        }

        public DateTime ReadDateInput()
        {
            string userCommandString = Console.ReadLine();
            DateTime.TryParse(userCommandString, out var userCommand);
            Console.WriteLine();

            return userCommand;
        }

        public string ReadWorkerInfo()
        {
            string[] lines = new string[7];
            Console.Write("ID: ");
            lines[0] = Console.ReadLine();
            lines[1] = DateTime.Now.ToString();
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

            Console.WriteLine();

            return string.Join("#", lines);
        }

        public void PrintAllWorkers(Worker[] workers)
        {
            foreach(Worker worker in workers)
            {
                PrintWorker(worker);
            }
        }

        public void PrintWorker(Worker worker)
        {
            string[] words = worker.GetStringWorkerInfo().Split('#');
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }
    }
}
