namespace Practice_18_Patterns.Models
{
    public interface IAnimal
    {
        string Class { get; set; }
        string Order { get; set; }
        string Family { get; set; }
        string Species { get; set; }
        public string Name { get; }
    }
}
