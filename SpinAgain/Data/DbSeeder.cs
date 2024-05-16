using Microsoft.EntityFrameworkCore;

using SpinAgain.Models;

namespace SpinAgain.Data;

public static class DbSeeder
{
    public static void SeedData(IServiceProvider serviceProvider)
    {
        using (var context = new SpinAgainDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<SpinAgainDbContext>>()))
        {
            // Check if data already exists
            if (context.Users.Any() || context.Bikes.Any() || context.Transactions.Any())
            {
                return; // Data already seeded
            }

            // Seed Users
            var user1 = new User { Username = "user1", Email = "user1@example.com", /* Other properties */ };
            var user2 = new User { Username = "user2", Email = "user2@example.com", /* Other properties */ };
            context.Users.AddRange(user1, user2);

            // Seed Bikes
            var bike1 = new Bike { /* Bike properties */ };
            var bike2 = new Bike { /* Bike properties */ };
            context.Bikes.AddRange(bike1, bike2);

            // Seed Transactions
            var transaction1 = new Transaction { BuyerId = user1.UserId, BikeId = bike1.BikeId, /* Transaction properties */ };
            var transaction2 = new Transaction { BuyerId = user2.UserId, BikeId = bike2.BikeId, /* Transaction properties */ };
            context.Transactions.AddRange(transaction1, transaction2);

            context.SaveChanges();
        }
    }
}
/*
 // In the Main method of program.cs
var host = CreateHostBuilder(args).Build();

using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SpinAgainDbContext>();
        DbSeeder.SeedData(services);
    }
    catch (Exception ex)
    {
        // Handle any errors that occur during seeding
        // Log the error or take appropriate action
    }
}

host.Run();
*/