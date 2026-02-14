using HobbyGarage.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HobbyGarage.Models;

namespace HobbyGarage.Controllers;

public class CartController : Controller
{
  // GET
  public IActionResult Index()
  {
    var cart = CartRepository.TryGetByUserId(Constans.UserId);
    return View(cart);
  }

  public IActionResult Add(int productId)
  {
    var product = RepositoryProduct.TryGetById(productId);

    if (product != null)
    {
      CartRepository.Add(product, Constans.UserId);
    }

    return RedirectToAction(nameof(Index));
  }
}