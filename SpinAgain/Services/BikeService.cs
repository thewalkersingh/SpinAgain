using Microsoft.EntityFrameworkCore;

using SpinAgain.Data;
using SpinAgain.Models;

namespace SpinAgain.Services;

public class BikeService : IBikeService
{
    private readonly SpinAgainDbContext _dbContext;

    public BikeService(SpinAgainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Bike GetBikeById(int bikeId)
    {
        return _dbContext.Bikes.FirstOrDefault(b => b.BikeId == bikeId);
    }

    public IEnumerable<Bike> GetAllBikes()
    {
        return _dbContext.Bikes.ToList();
    }

    public void CreateBike(Bike bike)
    {
        _dbContext.Bikes.Add(bike);
        _dbContext.SaveChanges();
    }

    public void UpdateBike(Bike bike)
    {
        _dbContext.Entry(bike).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteBike(int bikeId)
    {
        var bike = _dbContext.Bikes.Find(bikeId);
        if (bike != null)
        {
            _dbContext.Bikes.Remove(bike);
            _dbContext.SaveChanges();
        }
    }
}
