namespace Practice_18_Patterns.Models {
    internal interface IAnimalSaver {
        void SaveAnimals(List<IAnimal> animals, string filePath);
    }
}
