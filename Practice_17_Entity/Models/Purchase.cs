namespace Practice_17_Entity;

public partial class Purchase
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string ItemId { get; set; } = null!;

    public string ItemName { get; set; } = null!;
}
