using Microsoft.AspNetCore.Mvc;
using HobbyGarage.Models;
using HobbyGarage.Repository;

namespace HobbyGarage.Controllers;


public class OrderController : Controller
{
  private readonly ICartRepository _cartRepository;
  private readonly IOrderRepository _orderRepository;

  public OrderController(ICartRepository cartRepository,IOrderRepository orderRepository)
  {
    _cartRepository = cartRepository;
    _orderRepository = orderRepository;
  }

  public IActionResult Index()
  {
    var _cart = _cartRepository.TryGetByUserId(Constans.UserId);
    return View(_cart);
  }
[HttpPost]
  public IActionResult Buy(DevileryInfo devilery)
  {
    var _cart = _cartRepository.TryGetByUserId(Constans.UserId);
    var newOrder = new Order()
    {
        UserId = Constans.UserId,
        Items = _cart.Items
    };
    _orderRepository.Add(newOrder);
    _cartRepository.Clear(Constans.UserId);

    return RedirectToAction("Succsess");
  }

  public IActionResult Succsess()
  {
    return View();
  }
}