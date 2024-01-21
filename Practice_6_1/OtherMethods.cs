using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_6_1
{
    internal class OtherMethods
    {
        static void AddNewItemByFile(string filePath, string itemText)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            File.AppendAllText(filePath, "\n" + itemText);
        }

        static void AddNewItemByFileStream(string filePath, string itemText)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Append))
            {
                using (StreamWriter stream = new StreamWriter(fileStream))
                {
                    stream.WriteLine(itemText);
                }
            }
        }

        static void PrintAllItemsByFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] fileStrings = File.ReadAllLines(filePath);
                foreach (string fileString in fileStrings)
                {
                    string[] words = fileString.Split('#');
                    foreach (string word in words)
                    {
                        Console.WriteLine(word);
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
