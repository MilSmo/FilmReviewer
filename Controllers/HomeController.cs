using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FilmReviewerApp.Models;

namespace FilmReviewerApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Retrieve the Films_Avg dictionary from the RatingCounter class
        var filmsAvg = RatingCounter.Films_Avg;

        // Pass the Films_Avg dictionary as the model to the view
        return View(filmsAvg);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
