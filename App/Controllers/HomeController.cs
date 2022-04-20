using App.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository _repository;

    public HomeController(ILogger<HomeController> logger, IRepository repo)
    {
        _logger = logger;
        _repository = repo;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        return View(new Models.ViewModels.Home.IndexModel(_repository));
    }

    [AllowAnonymous]
    public IActionResult Privacy()
    {
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new Models.Error { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
