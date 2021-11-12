namespace EFDataAccessLibrary.Models;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Dish> Dishes { get; set; }
}