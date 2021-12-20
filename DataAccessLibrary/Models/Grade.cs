namespace DataAccessLayer.Models;

public class Grade
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }

    public short Value { get; set; }
}