using System.IO;

namespace Practice_18_Patterns.Models {
    class AnimalSaverTxt : IAnimalSaver {
        public void SaveAnimals(List<IAnimal> animals, string filePath) {
            filePath += "\\animals.txt";
            using(StreamWriter sw = new StreamWriter(filePath)) {
                foreach(IAnimal animal in animals) {
                    sw.WriteLine(animal.Name);
                }
            }
        }
    }
}
