namespace DataAccessLayer.Models;

public class Cuisine
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public List<Dish> Dishes { get; set; }

    public Cuisine() => Dishes = new();
}
