using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using System.Text.Json;
using System.Text;

namespace OnlineStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        {
    var path = Path.Combine(
        Directory.GetCurrentDirectory(),
        "data",
        "Products.json"
    );

    var json = System.IO.File.ReadAllText(path);

    var products = JsonSerializer.Deserialize<List<Product>>(json);

    var sb = new StringBuilder();

    foreach (var product in products)
    {
        sb.AppendLine(product.Id.ToString());
        sb.AppendLine(product.Name);
        sb.AppendLine(product.Cost.ToString());
        sb.AppendLine(); 
    }
    return View();
    }
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
