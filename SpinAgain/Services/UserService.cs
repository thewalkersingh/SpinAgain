using Microsoft.EntityFrameworkCore;

using SpinAgain.Data;
using SpinAgain.Models;

namespace SpinAgain.Services;

public class UserService : IUserService
{
    private readonly SpinAgainDbContext _dbContext;

    public UserService(SpinAgainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User GetUserById(int userId)
    {
        return _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _dbContext.Users.ToList();
    }

    public void CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _dbContext.Entry(user).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = _dbContext.Users.Find(userId);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
