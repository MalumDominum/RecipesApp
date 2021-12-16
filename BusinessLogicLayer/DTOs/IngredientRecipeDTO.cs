namespace BusinessLogicLayer.DTOs;

public class IngredientRecipeDTO
{
    public int IngredientId { get; set; }

    public int RecipeId { get; set; }

    public double? Amount { get; set; }
    public string? UnitName { get; set; }
}
