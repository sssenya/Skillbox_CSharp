namespace Practice_18_Patterns.Models
{
    class Bird : IAnimal
    {

        public Bird()
        {
            Class = "Птицы";
        }

        public string Class { get; set; }
        public string Order { get; set; }
        public string Family { get; set; }
        public string Species { get; set; }
    }
}
