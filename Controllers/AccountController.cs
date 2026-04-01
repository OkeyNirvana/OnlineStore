using Microsoft.AspNetCore.Mvc;
using HobbyGarage.Models;

namespace HobbyGarage.Controllers;

public class AccountController : Controller
{
  [HttpGet]
  public IActionResult Login()
  {
    return View();
  }
  [HttpPost]
  public IActionResult Login(Login login)
  {
    return View();
  }
  [HttpGet]
  public IActionResult Registration()
  {
    return View();
  }
  [HttpPost]
  public IActionResult Registration(string name, string password, string password2)
  {
    return View();
  }
  
}