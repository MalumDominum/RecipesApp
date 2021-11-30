namespace BusinessLogicLayer.DTOs;

public class DishDTO
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int CuisineId { get; set; }

    public int CategoryId { get; set; }
}
