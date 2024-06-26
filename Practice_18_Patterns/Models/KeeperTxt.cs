using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18_Patterns.Models
{
    class KeeperTxt : IAnimalSave
    {
        public KeeperTxt(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }

        public void SaveAnimals(List<IAnimal> animals)
        {
            using (StreamWriter sw = new StreamWriter($"{FileName}\\animals.txt"))
            {
                foreach(IAnimal animal in animals)
                {
                    sw.WriteLine(animal.Name);
                }
            }
        }
    }
}
