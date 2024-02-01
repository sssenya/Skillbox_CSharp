using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = CreateList();
            PrintList(intList);
            Console.WriteLine();

            List<int> updatedList = DeleteItemsFromList(intList, 25, 50);

            PrintList(updatedList);
            Console.ReadLine();
        }

        private static List<int> CreateList()
        {
            List<int> intList = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 101; i++)
            {
                intList.Add(random.Next(100));
            }

            return intList;
        }

        private static List<int> DeleteItemsFromList(List<int> intList, int minValue, int maxValue)
        {
            for(int i = 0; i < intList.Count - 1; i++)
            {
                if(intList[i] > minValue && intList[i] < maxValue)
                {
                    intList.Remove(intList[i]);
                    i--;
                }
            }
            return intList;
        }

        private static void PrintList(List<int> intList)
        {
            for (int i = 0; i < intList.Count - 1; i++)
            {
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine(intList[i]);
                }
                else
                {
                    Console.Write(intList[i] + " ");
                }
            }
        }
    }
}
