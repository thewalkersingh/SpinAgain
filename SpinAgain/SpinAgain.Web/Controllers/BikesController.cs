using Microsoft.AspNetCore.Mvc;

using SpinAgain.Web.Data;
using SpinAgain.Web.Models;

namespace SpinAgain.Web.Controllers;

public class BikesController : Controller
{
    private SpinAgainDBContext _dbContext;
    public BikesController(SpinAgainDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        var bikes = _dbContext.Bikes.ToList();
        return View(bikes);
    }
    public IActionResult Services()
    {
        return View();
    }
    public IActionResult FeaturedBikes()
    {
        return View();
    }
    public IActionResult NewBikes()
    {
        return View();
    }
    public IActionResult Brands()
    {
        return View();
    }


}
