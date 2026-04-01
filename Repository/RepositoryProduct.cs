using HobbyGarage.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyGarage.Repository
{
  public interface IRepositoryProduct
  {
    public List<Product> GetAll();
    public Product TryGetById(int id);
    public void Add(Product product);
    public void DeleteProduct(int productid);
  }
  public class RepositoryProduct : IRepositoryProduct
  {
    private static int _instanceCounter = 0;

    private List<Product> _products = new List<Product>
    {
        new Product(++_instanceCounter, "Какя то хуйня", 100, "Описание 1"),
        new Product(++_instanceCounter, "Еще одна хуйня", 500, "Описание 2"),
        new Product(++_instanceCounter, "Очередная хуета", 300, "Описание 3"),
        new Product(++_instanceCounter, "Шляпа", 100, "Описание 4"),
        new Product(++_instanceCounter, "Какая то шляпа", 500, "Описание 5"),
        new Product(++_instanceCounter, "Еще шляпа", 300, "Описание 6")
    };

    private IRepositoryProduct _repositoryProductImplementation;
    public List<Product> GetAll() => _products;
    
    public Product TryGetById(int id)
    {
      foreach (var product in _products)
      {
        if (product.Id == id)
          return product;
      }

      return null;
    }

    public void Add(Product product)
    {
      product.Id = ++_instanceCounter;
      _products.Add(product);
    }

    public void DeleteProduct(int productid)
    {
      var product = TryGetById(productid);
      _products.Remove(product);
    }
  }
}