namespace DataAccessLayer.Models;

public class DishPortion
{
    public int Id { get; set; }

    public double Weight { get; set; }

    public int? Calories { get; set; }

    public int? Proteins { get; set; }

    public int? Fats { get; set; }

    public int? Carbs { get; set; }
}
