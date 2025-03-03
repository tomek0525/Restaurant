namespace Restaurant.Domain;

public class Food
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}