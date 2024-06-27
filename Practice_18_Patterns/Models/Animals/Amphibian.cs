namespace Practice_18_Patterns.Models {
    class Amphibian : IAnimal {
        public Amphibian(string order, string family, string species) {
            Class = "Земноводные";
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
