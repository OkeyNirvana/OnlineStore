using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers;

public class Contact : Controller
{
  // GET
  public IActionResult Index()
  {
    return View();
  }
} 