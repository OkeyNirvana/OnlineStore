using HobbyGarage.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HobbyGarage.Models;

namespace HobbyGarage.Controllers;

public class CartController : Controller
{
  private readonly IRepositoryProduct _repositoryProduct;
  private readonly ICartRepository _cartRepository;

  public  CartController(IRepositoryProduct repositoryProduct,ICartRepository cartRepository)
  {
    _repositoryProduct = repositoryProduct;
    _cartRepository = cartRepository;
  }
  public IActionResult Index()
  {
    var cart = _cartRepository.TryGetByUserId(Constans.UserId);
    return View(cart);
  }

  public IActionResult Add(int productId)
  {
    var product = _repositoryProduct.TryGetById(productId);

    if (product != null)
    {
      _cartRepository.Add(product, Constans.UserId);
    }

    return RedirectToAction(nameof(Index));
  }
  public IActionResult AddQuantity(int productId)
  {
    _cartRepository.AddQuantity(Constans.UserId, productId);
    return RedirectToAction(nameof(Index));
  }

  public IActionResult RemoveQuantity(int productId)
  {
    _cartRepository.RemoveQuantity(Constans.UserId, productId);
    return RedirectToAction(nameof(Index));
  }
}