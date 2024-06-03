using SpinAgain.Web.Models;

namespace SpinAgain.Web.Data
{
    public class BikeInitializer
    {
        public static void Initialize(SpinAgainDBContext context)
        {
            if (context.Bikes.Any())
                return;
            var bikes = new List<Bike>
            {
                new Bike { Id = 1, ModelName = "Apache RTR 200", Brand = "TVS", Price = 175000, CC = 200, ImageUrl = "", MeterReading = 0, RegistrationNo = "ABC123" },
            new Bike { Id = 2, ModelName = "FZ V4", Brand = "Yamaha", Price = 155000, CC = 150, ImageUrl = "", MeterReading = 0, RegistrationNo = "DEF456" },
            new Bike { Id = 3, ModelName = "Pulsar 200", Brand = "Bajaj", Price = 160000, CC = 200, ImageUrl = "", MeterReading = 0, RegistrationNo = "GHI789" },
            new Bike { Id = 4, ModelName = "MT-15", Brand = "Yamaha", Price = 172000, CC = 155, ImageUrl = "", MeterReading = 0, RegistrationNo = "JKL012" }
            };
            foreach (var bike in bikes)
            {
                context.Bikes.Add(bike);
            }
            context.SaveChanges();
        }
    }
}
