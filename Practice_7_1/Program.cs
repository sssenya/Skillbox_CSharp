using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            ConsoleReader reader = new ConsoleReader();

            int userCommand = 1;

            while(userCommand != 0)
            {
                Console.WriteLine("Введите команду:");
                Console.WriteLine("1 - вывести все записи на экран");
                Console.WriteLine("2 - добавить новую запись");
                Console.WriteLine("3 - удалить существующую запись");
                Console.WriteLine("4 - найти запись по ID");
                Console.WriteLine("5 - найти записи в диапозоне дат создания");
                Console.WriteLine();
                Console.WriteLine("0 - выход из программы");
                Console.WriteLine();

                userCommand = reader.ReadIntInput();

                switch (userCommand)
                {
                    case 1:
                        Console.WriteLine(" Введите поле для сортировки записей"); 
                        Console.WriteLine("1 - ID");
                        Console.WriteLine("2 - ФИО");
                        Console.WriteLine("3 - дата добавления записи");
                        int sortOrder = reader.ReadIntInput();

                        Worker[] workers = repository.GetAllWorkers();

                        switch (sortOrder)
                        {
                            case 1:
                                workers = workers.OrderBy(x => x.Id).ToArray();
                                break;
                            case 2:
                                workers = workers.OrderBy(x => x.FIO).ToArray();
                                break;
                            case 3:
                                workers = workers.OrderBy(x => x.CreationTime).ToArray();
                                break;
                            default:
                                Console.WriteLine("Команда введена не верно");
                                break;

                        }

                        reader.PrintAllWorkers(workers);
                        break;                 
                    case 2:
                        string workerString = reader.ReadWorkerInfo();
                        Worker newWorker = new Worker();
                        newWorker.ReadWorkerFromString(workerString);

                        repository.AddWorker(newWorker);
                        break;                  
                    case 3:
                        Console.Write("Введите ID: ");
                        int idToDelete = reader.ReadIntInput();

                        repository.DeleteWorker(idToDelete);
                        break;                  
                    case 4:
                        Console.Write("Введите ID: ");
                        int id = reader.ReadIntInput();

                        Worker worker = repository.GetWorkerById(id);

                        reader.PrintWorker(worker);
                        break;                  
                    case 5:
                        Console.Write("Введите первую дату: ");
                        DateTime dateFrom = reader.ReadDateInput();
                        Console.Write("Введите вторую дату: ");
                        DateTime dateTo = reader.ReadDateInput();

                        Worker[] filteredWorkers = repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);

                        reader.PrintAllWorkers(filteredWorkers);

                        break;
                    default:
                        Console.WriteLine("Команда введена не верно");
                        break;
                }
            }
        }
    }
}
