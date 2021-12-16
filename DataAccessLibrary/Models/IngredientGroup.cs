namespace DataAccessLayer.Models;

public class IngredientGroup
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Ingredient> Ingredients { get; set; }

    public IngredientGroup() => Ingredients = new();
}
