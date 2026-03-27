using HobbyGarage.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HobbyGarage.Models;

namespace HobbyGarage.Controllers;

public class FavoriteController : Controller
{
  private readonly IRepositoryProduct  _productRepository;

  private readonly IFavoriteRepository _favoriteRepository;

  public FavoriteController(IRepositoryProduct productRepository, IFavoriteRepository favoriteRepository)
  {
    _favoriteRepository = favoriteRepository;
    _productRepository = productRepository;
  }
  // GET
  public IActionResult Index()
  {
    var favorite = _favoriteRepository.TryGetByUserId(Constans.UserId);
    return View(favorite);
  }

  public IActionResult Add(int productId)
  {
    var product = _productRepository.TryGetById(productId);

    if (product != null)
    {
      _favoriteRepository.Add(product, Constans.UserId);
    }

    return RedirectToAction(nameof(Index));
  }
  
  public IActionResult Delete(int productId)
  {
    _favoriteRepository.Delete(productId, Constans.UserId);
            
    return RedirectToAction(nameof(Index));
  }
  public IActionResult Clear()
  {
    _favoriteRepository.Clear(Constans.UserId);

    return RedirectToAction(nameof(Index));
  }
  
}