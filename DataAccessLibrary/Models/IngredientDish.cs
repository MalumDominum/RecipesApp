namespace DataAccessLayer.Models;

public class IngredientDish
{
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }

    public int DishId { get; set; }
    public Dish Dish { get; set; }
}
