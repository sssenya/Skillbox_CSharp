namespace Practice_18_Patterns.Models {
    class Bird : IAnimal {
        public Bird(string order, string family, string species) {
            Class = "Птицы";
            Order = order;
            Family = family;
            Species = species;
        }

        public string Class { get; set; }
        public string Order { get; set; }
        public string Family { get; set; }
        public string Species { get; set; }
        public string Name => $"{Class} {Order} {Family} {Species}";
    }
}
