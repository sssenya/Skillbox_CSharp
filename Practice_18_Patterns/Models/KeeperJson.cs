using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Newtonsoft.Json;

namespace Practice_18_Patterns.Models
{
    class KeeperJson : IAnimalSave
    {
        public KeeperJson(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }

        public void SaveAnimals(List<IAnimal> animals)
        {
            FileName += "\\animals.json";
            using (StreamWriter file = File.CreateText(FileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, animals);
            }
        }
    }
}
