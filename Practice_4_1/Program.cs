using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите количество строк в матрице:");
            string userLinesAmount = Console.ReadLine();
            int linesAmount = int.Parse(userLinesAmount);

            Console.WriteLine("Здравствуйте! Введите количество столбцов в матрице:");
            string userColumnsAmount = Console.ReadLine();
            int columnsAmount = int.Parse(userColumnsAmount);

            int[,] matrix = new int[linesAmount, columnsAmount];
            Random random = new Random();
            int sum = 0;

            for (int i = 0; i < linesAmount; i++)
            {
                for (int j = 0; j < columnsAmount; j++)
                {
                    matrix[i, j] = random.Next(1000);
                    sum += matrix[i, j];
                    
                    Console.Write($"{matrix[i, j], 6}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Сумма элементов матрицы равна {sum}");
            Console.ReadKey();
        }
    }
}
