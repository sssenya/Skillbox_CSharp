using System.IO;

using Newtonsoft.Json;

namespace Practice_18_Patterns.Models {
    class AnimalSaverJson : IAnimalSaver {
        public void SaveAnimals(List<IAnimal> animals, string filePath) {
            filePath += "\\animals.json";
            using(StreamWriter file = File.CreateText(filePath)) {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, animals);
            }
        }
    }
}
