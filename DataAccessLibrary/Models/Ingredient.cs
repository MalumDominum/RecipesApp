namespace DataAccessLayer.Models;

public class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; }

    public byte[]? Image { get; set; }

    public string? Description { get; set; }

    public int GroupId { get; set; }
    public IngredientGroup Group { get; set; }

    public List<IngredientRecipe> IngredientRecipePairs { get; set; }

    public Ingredient() => IngredientRecipePairs = new();
}
