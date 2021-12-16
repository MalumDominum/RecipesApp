namespace BusinessLogicLayer.DTOs;

public class RecipeDTO
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

    public int CategoryId { get; set; }

    public int AuthorId { get; set; }
}
