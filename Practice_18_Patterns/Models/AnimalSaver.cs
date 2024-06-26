namespace Practice_18_Patterns.Models
{
    class AnimalSaver
    {
        public AnimalSaver(IAnimalSave animaSave)
        {
            SaveMode = animaSave;
        }

        public IAnimalSave SaveMode { get; set; }
        public List<IAnimal> Animals { get; set; }

        public void Save()
        {
            SaveMode.SaveAnimals(Animals);
        }
    }
}
