using SpinAgain.Models;

namespace SpinAgain.Services;

public interface IBikeService
{
    Bike GetBikeById(int bikeId);
    IEnumerable<Bike> GetAllBikes();
    void CreateBike(Bike bike);
    void UpdateBike(Bike bike);
    void DeleteBike(int bikeId);
}
