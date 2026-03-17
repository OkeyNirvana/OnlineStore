namespace HobbyGarage.Models;

public interface ICartRepository
{
  public Cart? TryGetByUserId(string userid);
  public void Add(Product product, string userId);
  public void AddQuantity(string userid, int puductid);
  public void RemoveQuantity(string userid, int productid);
  void Clear(string userId);

}

public class CartRepository : ICartRepository
{
  public  List<Cart> _carts = [];
  public Cart? TryGetByUserId(string userid)
  {
    return _carts.FirstOrDefault(cart => cart.UserId == userid);
  }
  
  public void Add(Product product, string userId)
  {
    var existingCart = TryGetByUserId(userId);

    if (existingCart == null)
    {
      existingCart = new Cart()
      {
          Id = Guid.NewGuid(),
          UserId = userId,
          Items = new List<CartItem>()
          {
              new CartItem()
              {
                  Product = product,
                  Quantity = 1,
                  Id = Guid.NewGuid()
              }
          }
      };
          _carts.Add(existingCart);
    }
    else
    {
      var existingCartItem = existingCart.Items.FirstOrDefault(item => 
          item.Product.Id == product.Id);
      if (existingCartItem == null)
      {
        var newCartItem = new CartItem()
        {
            Id = Guid.NewGuid(),
            Product = product,
            Quantity = 1
        };
        existingCart.Items.Add(newCartItem);
      }
      else
      {
        existingCartItem.Quantity++;
      }
    }
  }

  public void AddQuantity(string userId, int productid)
  {
    var existingCart = TryGetByUserId(userId);
    if (existingCart == null) return;
    var existingCartItem = existingCart.Items.FirstOrDefault(item =>
        item.Product.Id == productid);
    existingCartItem.Quantity++;

  }

  public void RemoveQuantity(string userid, int productid)
  {
    var existingCart = TryGetByUserId(userid);
    if (existingCart == null) return;
    var existingCartItem = existingCart.Items.FirstOrDefault(item =>
        item.Product.Id == productid);
    if (existingCartItem.Quantity > 0) existingCartItem.Quantity--;
    if (existingCartItem.Quantity == 0) existingCart.Items.Remove(existingCartItem);
    
  }
  public void Clear(string userId)
  {
    var cart = TryGetByUserId(userId);

    if (cart != null)
    {
      cart.Items.Clear();
    }
  }
}

