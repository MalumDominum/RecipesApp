namespace DataAccessLayer.Models;

public class Grade
{
    public int Id { get; set; }

    public short Value { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}