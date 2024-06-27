namespace Practice_18_Patterns.Models {
    class Mammal : IAnimal {
        public Mammal(string order, string family, string species) {
            Class = "Млекопитающие";
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
