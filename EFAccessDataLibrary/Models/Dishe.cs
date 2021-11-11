namespace EFDataAccessLibrary.Models;

public class Dishe
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? Calories { get; set; }

    public int? Proteins { get; set; }

    public int? Fats { get; set; }

    public int? Carbs { get; set; }

    public List<Ingredient> Ingredients { get; set; }

    public Dishe()
    {

    }
}
