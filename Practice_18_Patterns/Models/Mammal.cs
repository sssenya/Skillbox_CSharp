namespace Practice_18_Patterns.Models
{
    class Mammal : IAnimal 
    {
        public Mammal() {
            Class = "Млекопитающие";
        }

        public string Class { get; set; }
        public string Order { get; set; }
        public string Family { get; set; }
        public string Species { get; set; }
    }
}
