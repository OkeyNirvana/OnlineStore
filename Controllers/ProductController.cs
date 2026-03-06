using HobbyGarage.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HobbyGarage.Controllers;

public class ProductController : Controller
{
  private readonly IRepositoryProduct _repositoryProduct;

  public ProductController(IRepositoryProduct repositoryProduct)
  {
    _repositoryProduct = repositoryProduct;
  }
  public IActionResult Index(int id)
  {
    var product = _repositoryProduct.TryGetById(id);
    
    return View(product);
  }

  public IActionResult Add(string name, decimal cost, string discription)
  {
    _repositoryProduct.Add(name, cost, discription);
    var product = _repositoryProduct.GetAll();

    return RedirectToAction("Index","Home");
    //return View("../Home/Index", product);
  }
}