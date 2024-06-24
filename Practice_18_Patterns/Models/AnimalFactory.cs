namespace Practice_18_Patterns.Models
{
    internal class AnimalFactory
    {
        public static IAnimal GetAnimal(string animalClass,
                                        string order,
                                        string family,
                                        string species)
        {
            switch (animalClass) {
                case "Земноводные": return new Amphibian(order, family, species);
                case "Млекопитающие": return new Mammal(order, family, species);
                case "Птицы": return new Bird(order, family, species);
                default: return new NullAnimal();
            }
        }
    }
}
