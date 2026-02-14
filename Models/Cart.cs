using System.Linq;
namespace HobbyGarage.Models;

public class Cart
{
  public List<CartItem> Items = [];
  public string? UserId;
  public Guid Id;
  public decimal? TotalCost => Items.Sum(item => item.Cost);

}

public class CartItem
{
  public Product? Product;
  public Guid Id;
  public int Quantity;
  public decimal? Cost => Quantity * Product.Cost;

}