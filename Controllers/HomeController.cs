using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using HobbyGarage.Models;
using HobbyGarage.Repository;


namespace HobbyGarage.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositoryProduct _repositoryProduct;
    

    public HomeController (IRepositoryProduct repositoryProduct, ILogger<HomeController> logger)
    {
        _repositoryProduct = repositoryProduct;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var products = _repositoryProduct.GetAll();
        
 
    return View(products);
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
