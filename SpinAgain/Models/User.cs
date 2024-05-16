namespace SpinAgain.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; }

    // Navigation property for bikes listed by this user
    public ICollection<Bike>? Bikes { get; set; }
}
public enum UserRole
{
    Seller,
    Buyer
}
