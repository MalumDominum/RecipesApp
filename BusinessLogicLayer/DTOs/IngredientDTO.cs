namespace BusinessLogicLayer.DTOs;

public class IngredientDTO
{
    public int Id { get; set; }

    public string Name { get; set; }

    public byte[]? Image { get; set; }

    public string? Description { get; set; }

    public int GroupId { get; set; }
}
