using HobbyGarage.Models;
using HobbyGarage.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HobbyGarage.Controllers;

public class СomparisonController : Controller
{
  private readonly IRepositoryProduct _repositoryProduct;

  private readonly IComparisonRepository _comparisonRepository;

  public СomparisonController(IRepositoryProduct repositoryProduct, IComparisonRepository comparisonRepository)
  {
    _repositoryProduct = repositoryProduct;
    _comparisonRepository = comparisonRepository;
  }
  // GET
  public IActionResult Index()
  {
    var comparison = _comparisonRepository.TryGetByUserId(Constans.UserId);
    return View(comparison);
  }
  public IActionResult Add(int productid)
  {
    var product = _repositoryProduct.TryGetById(productid);
    if (product != null) _comparisonRepository.Add(product,Constans.UserId);
    
    return RedirectToAction(nameof(Index));
  }
  public IActionResult Delete(int productid)
  {
    _comparisonRepository.Delete(productid,Constans.UserId);
    return RedirectToAction(nameof(Index));
  }
  public IActionResult Clear()
  {
    _comparisonRepository.Clear(Constans.UserId);
    return RedirectToAction(nameof(Index));
  }
}