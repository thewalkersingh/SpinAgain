using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using SpinAgain.Web.Models;

namespace SpinAgain.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult HomePage()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Services()
    {
        return View();
    }
    public IActionResult Contact() { 
        return View(); 
    }

}
