using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2_1
{
    internal class Task_1
    {
        static void Main(string[] args)
        {
            string fullName = "Иванов Иван Иванович";
            int age = 20;
            string email = "email@mail.ru";
            double programmingScore = 90.4;
            double mathScore = 54.7;
            double physicsScore = 77.77;

            Console.WriteLine($"ФИО: {fullName}\n" +
                              $"Возраст: {age}\n" +
                              $"Email: {email}\n" +
                              $"Баллы по программированию: {programmingScore}\n" +
                              $"Баллы по математике: {mathScore}\n" +
                              $"Баллы по физике: {physicsScore}");
            Console.ReadKey();

            double totalScore = programmingScore + mathScore + physicsScore;
            double averageScore = totalScore / 3;

            Console.WriteLine($"Сумма баллов: {totalScore}\n" +
                              $"Средний балл: {averageScore}");
            Console.ReadKey();
        }
    }
}
