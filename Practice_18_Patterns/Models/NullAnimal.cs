namespace Practice_18_Patterns.Models
{
    internal class NullAnimal : IAnimal
    {
        public NullAnimal()
        {
            Class = "Неизвестно";
            Order = "Неизвестно";
            Family = "Неизвестно";
            Species = "Неизвестно";
        }

        public string Class { get; set; }
        public string Order { get; set; }
        public string Family { get; set; }
        public string Species { get; set; }
    }
}
