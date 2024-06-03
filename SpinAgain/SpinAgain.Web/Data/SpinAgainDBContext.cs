//using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpinAgain.Web.Models;

namespace SpinAgain.Web.Data;

public class SpinAgainDBContext : DbContext
{
    public SpinAgainDBContext(DbContextOptions options) : base(options) { }
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Bike>()
            .Property(b => b.Price)
            .HasColumnType("decimal(18,2)"); // Adjust precision and scale as needed

        // Seed data
        modelBuilder.Entity<Bike>().HasData(
            new Bike { Id = 1, ModelName = "Apache RTR 200", Brand = "TVS", Price = 175000, CC = 200, ImageUrl = "", MeterReading = 0, RegistrationNo = "ABC123" },
            new Bike { Id = 2, ModelName = "FZ V4", Brand = "Yamaha", Price = 155000, CC = 150, ImageUrl = "", MeterReading = 0, RegistrationNo = "DEF456" },
            new Bike { Id = 3, ModelName = "Pulsar 200", Brand = "Bajaj", Price = 160000, CC = 200, ImageUrl = "", MeterReading = 0, RegistrationNo = "GHI789" },
            new Bike { Id = 4, ModelName = "MT-15", Brand = "Yamaha", Price = 172000, CC = 155, ImageUrl = "", MeterReading = 0, RegistrationNo = "JKL012" }
        );
    }
}

