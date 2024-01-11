using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linesAmount = GetMatrixSize("Здравствуйте! Введите количество строк в матрице:");
            int columnsAmount = GetMatrixSize("Здравствуйте! Введите количество столбцов в матрице:");

            int[,] matrixFirst = new int[linesAmount, columnsAmount];
            int[,] matrixSecond = new int[linesAmount, columnsAmount];
            int[,] matrixSum = new int[linesAmount, columnsAmount];

            Random random = new Random();
            int iSum;

            for (int i = 0; i < linesAmount; i++)
            {
                for (int j = 0; j < columnsAmount; j++)
                {
                    matrixFirst[i, j] = random.Next(100);
                    matrixSecond[i, j] = random.Next(100);
                    iSum = matrixFirst[i, j] + matrixSecond[i, j];
                    matrixSum[i, j] = iSum;
                }
            }

            PrintMatrix(matrixFirst, "Первая матрица");
            PrintMatrix(matrixSecond, "Вторая матрица");
            PrintMatrix(matrixSum, "Суммарная матрица");
            Console.ReadKey();
        }

        static int GetMatrixSize(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }

        static void PrintMatrix(int[,] matrix, string description)
        {
            Console.WriteLine(description);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],6}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
