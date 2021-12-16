namespace DataAccessLayer.Models;

public class Dish
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int CuisineId { get; set; }
    public Cuisine Cuisine { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public List<DishPortion> DishPortions { get; set; }

    public List<IngredientDish> IngredientDishPairs { get; set; }

    public List<OrderDish> OrderDishPairs { get; set; }

    public List<Bookmark> Bookmarks { get; set; }

    public Dish()
    {
        DishPortions = new();
        IngredientDishPairs = new();
        OrderDishPairs = new();
    }
}
