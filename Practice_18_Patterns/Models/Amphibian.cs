namespace Practice_18_Patterns.Models
{
    class Amphibian : IAnimal 
    {
        public Amphibian() {
            Class = "Земноводные";
        }

        public string Class { get; set; }
        public string Order { get; set; }
        public string Family { get; set; }
        public string Species { get; set; }
    }
}
