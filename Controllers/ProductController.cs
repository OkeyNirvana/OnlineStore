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
}