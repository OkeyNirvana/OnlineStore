using HobbyGarage.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyGarage.Views.Shared.Components;

public class CartViewComponent(ICartRepository cartRepository) :ViewComponent
{
  public IViewComponentResult Invoke()
  {
    var cart = cartRepository.TryGetByUserId(Constans.UserId);
    var product = cart?.Quantity ?? 0;

    return View("Cart", product);

  }
}