namespace SpinAgain.Models;

public class Transaction
{
    public int TransactionId { get; set; }
    public int BuyerId { get; set; }
    public int BikeId { get; set; }
    public DateTime TransactionDate { get; set; }

    public long TransactionAmount { get; set; }
    public Bike? Bike { get; set; }
}
