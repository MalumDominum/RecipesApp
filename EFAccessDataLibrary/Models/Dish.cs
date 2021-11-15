namespace EFDataAccessLibrary.Models;

public class Dish
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public Cuisine Cuisine { get; set; }

    public Category Category { get; set; }

    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public List<DishPortion> DishPortions { get; set; } = new List<DishPortion>();

    public List<Order> Orders { get; set; } = new List<Order>();
}
