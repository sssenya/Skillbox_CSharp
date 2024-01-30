using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7_1
{
    class Repository
    {
        private readonly string _filePath;

        public Repository()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + "\\Workers\\workers_list.txt";

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        public Worker[] GetAllWorkers()
        {
            int fileLength = File.ReadAllLines(_filePath).Length;
            Worker[] workers = new Worker[fileLength];

            int i = 0;

            using (StreamReader stream = new StreamReader(_filePath))
            {
                while (!stream.EndOfStream)
                {
                    var worker = new Worker();
                    worker.ReadWorkerFromString(stream.ReadLine());
                    workers[i] = worker;
                    i ++;
                }
            }

            return workers;
        }

        public void DeleteWorker(int id)
        {
            Worker[] workers = GetAllWorkers();

            using (StreamWriter stream = new StreamWriter(_filePath, false))
            {
                foreach(var worker in workers)
                {
                    if(worker.Id != id)
                    {
                        stream.WriteLine(worker.GetStringWorkerInfo());
                    }
                }
            }
        }

        public void AddWorker(Worker worker)
        {
            string workerString = worker.GetStringWorkerInfo();

            using (StreamWriter stream = new StreamWriter(_filePath, true))
            {
                stream.WriteLine(workerString);
            }
        }

        public Worker GetWorkerById(int id)
        {
            Worker[] workers = GetAllWorkers();

            foreach(var worker in workers)
            {
                if (worker.Id == id)
                {
                    return worker;
                }
            }
            return new Worker();
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = GetAllWorkers();
            List<Worker> filteredWorkers = new List<Worker>();

            foreach (var worker in workers)
            {
                if (worker.CreationTime > dateFrom && worker.CreationTime < dateTo)
                {
                    filteredWorkers.Add(worker);
                }
            }
            return filteredWorkers.ToArray();
        }
    }
}

