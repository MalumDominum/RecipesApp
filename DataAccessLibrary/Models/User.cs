namespace DataAccessLayer.Models;

public class User
{
    public int Id { get; set; }

    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime RegistrationTime { get; set; }

    public List<Bookmark> Bookmarks { get; set; }
}