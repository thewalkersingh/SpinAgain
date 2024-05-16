namespace SpinAgain.Models;

public class Bike
{
    public int BikeId { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }

    public long Price { get; set; }
    public string? Description { get; set; }
    public int CurrentRunning { get; set; }
    public int CC { get; set; }
    // Foreign key property
    public int UserId { get; set; }
    // Navigation property for the seller (User)
    public User? Seller { get; set; }
}
