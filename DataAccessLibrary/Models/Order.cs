namespace DataAccessLayer.Models;

public class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; }

    public DateTime RequestTime { get; set; }

    public DateTime? ServingTime { get; set; }

    public List<OrderDish> OrderDishPairs { get; set; }

    public Order() => OrderDishPairs = new();
}
