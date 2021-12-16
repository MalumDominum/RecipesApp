namespace DataAccessLayer.Models;

public class Recipe
{
    public int Id { get; set; }

    public string Name { get; set; }

    public byte[]? Image { get; set; }

    public short CookingTime { get; set; }

    public short? Calories { get; set; }
    public short? Proteins { get; set; }
    public short? Fats { get; set; }
    public short? Carbs { get; set; }

    public string? Description { get; set; }
    public string Steps { get; set; }

    public int CuisineId { get; set; }
    public Cuisine Cuisine { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int AuthorId { get; set; }
    public User Author { get; set; }

    public List<Bookmark> Bookmarks { get; set; }

    public List<IngredientRecipe> IngredientRecipePairs { get; set; }

    public Recipe() 
    { 
        Bookmarks = new();
        IngredientRecipePairs = new();
    }
}
