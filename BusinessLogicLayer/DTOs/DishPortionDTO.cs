namespace BusinessLogicLayer.DTOs;

public class DishPortionDTO
{
    public int Id { get; set; }

    public double Cost { get; set; }

    public double Weight { get; set; }

    public double? Calories { get; set; }

    public double? Proteins { get; set; }

    public double? Fats { get; set; }

    public double? Carbs { get; set; }

    public int DishId { get; set; }
}
