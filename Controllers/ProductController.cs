using HobbyGarage.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HobbyGarage.Controllers;

public class ProductController : Controller
{
  // GET
  public IActionResult Index(int id)
  {
    var product = RepositoryProduct.TryGetById(id);
    
    return View(product);
  }

  public IActionResult Add(string name, decimal cost, string discription)
  {
    RepositoryProduct.Add(name, cost, discription);
    var product = RepositoryProduct.GetAll();

    return RedirectToAction("Index","Home");
    //return View("../Home/Index", product);
  }
}