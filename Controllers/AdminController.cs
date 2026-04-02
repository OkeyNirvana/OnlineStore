using HobbyGarage.Models;
using HobbyGarage.Repository;
using Microsoft.AspNetCore.Mvc;


namespace HobbyGarage.Controllers;
    public class AdminController : Controller
    {
      private readonly IRepositoryProduct _repositoryProduct;

      public AdminController(IRepositoryProduct repositoryProduct)
      {
        _repositoryProduct = repositoryProduct;
      }
      public IActionResult Orders()
      {
        return View();
      }

      public IActionResult Products()
      {
        var product = _repositoryProduct.GetAll();
        return View(product);
      }

      public IActionResult Roles()
      {
        return View();
      }

      public IActionResult Users()
      {
        return View();
      }

      public IActionResult AddProduct()
      {
        return View();
      }
      [HttpPost]
      public IActionResult AddProduct(Product product)
      {
        _repositoryProduct.Add(product);
        return RedirectToAction("Products");
      }

      public IActionResult DeleteProduct(int id)
      {
        _repositoryProduct.DeleteProduct(id);
        return RedirectToAction("Products");
      }

      public IActionResult UpdateProduct(int id)
      {
        var existingProduct = _repositoryProduct.TryGetById(id);
        return View(existingProduct);
      }
      [HttpPost]
      public IActionResult UpdateProduct(Product product)
      {
        _repositoryProduct.UpdateProduct(product);
        return RedirectToAction("Products");
      }
    }
    