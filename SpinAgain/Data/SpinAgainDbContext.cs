using Microsoft.EntityFrameworkCore;

using SpinAgain.Models;

namespace SpinAgain.Data;

public class SpinAgainDbContext : DbContext
{
    public SpinAgainDbContext(DbContextOptions<SpinAgainDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Transaction> Transactions { get; set; }



}
