using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7_1
{
    internal struct Worker
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CityOfBirth { get; set; }

        public void ReadWorkerFromString(string workerString)
        {
            string[] words = workerString.Split('#');

            Id = int.Parse(words[0]);
            CreationTime = DateTime.Parse(words[1]);
            FIO = words[2];
            Age = int.Parse(words[3]);
            Height = int.Parse(words[4]);
            DateOfBirth = DateTime.Parse(words[5]);
            CityOfBirth = words[6];
        }

        public string GetStringWorkerInfo()
        {
            string[] lines = new string[7];

            lines[0] = Id.ToString();
            lines[1] = CreationTime.ToString();
            lines[2] = FIO;
            lines[3] = Age.ToString();
            lines[4] = Height.ToString();
            lines[5] = DateOfBirth.ToString();
            lines[6] = CityOfBirth.ToString();

            return string.Join("#", lines);
        }
    }
}
