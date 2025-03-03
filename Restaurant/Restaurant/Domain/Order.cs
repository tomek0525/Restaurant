namespace Restaurant.Domain;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; } = new ();
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
