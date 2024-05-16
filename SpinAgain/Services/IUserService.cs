using SpinAgain.Models;

namespace SpinAgain.Services;

public interface IUserService
{
    User GetUserById(int userId);
    IEnumerable<User> GetAllUsers();
    void CreateUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}
