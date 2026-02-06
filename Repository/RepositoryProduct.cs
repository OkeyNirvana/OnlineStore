using HobbyGarage.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyGarage.Repository
{
  public class RepositoryProduct
  {
    private static int _instanceCounter = 0;

    private static List<Product> _products = new List<Product>
    {
        new Product(++_instanceCounter, "Phone", 100, "Описание 1"),
        new Product(++_instanceCounter, "Laptop", 500, "Описание 2"),
        new Product(++_instanceCounter, "Tablet", 300, "Описание 3"),
        new Product(++_instanceCounter, "Phone", 100, "Описание 4"),
        new Product(++_instanceCounter, "Laptop", 500, "Описание 5"),
        new Product(++_instanceCounter, "Tablet", 300, "Описание 6")
    };
    public static List<Product> GetAll() => _products;
    
    public static Product TryGetById(int id)
    {
      foreach (var product in _products)
      {
        if (product.Id == id)
          return product;
      }

      return null;
    }

    public static void Add(string name, decimal cost, string discription)
    {
      var product = new Product(++_instanceCounter, name, cost, discription);
      _products.Add(product);
    }

  }
}