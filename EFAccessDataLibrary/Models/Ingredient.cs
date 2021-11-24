namespace DataAccessLayer.Models;

public class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public List<Dish> Dishes { get; set; } = new List<Dish>();
}
