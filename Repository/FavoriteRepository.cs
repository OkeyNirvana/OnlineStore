using HobbyGarage.Models;
namespace HobbyGarage.Repository;

public interface IFavoriteRepository
{
  public Favorite? TryGetByUserId(string userid);
  public void Add(Product product, string userId);
  public void Delete(int productid, string userId);
  void Clear(string userId);

}

public class FavoriteRepository : IFavoriteRepository
{
  private  List<Favorite> _favorite = [];
  
  public Favorite? TryGetByUserId(string userid)
  {
    return _favorite.FirstOrDefault(x => x.UserId == userid);
  }

  public void Add(Product product, string userId)
  {
    var existingFavourite = TryGetByUserId(userId);
    if (existingFavourite == null)
    {
      existingFavourite = new Favorite()
      {
          Items = [product],
          UserId = userId,
          Id = Guid.NewGuid()
      };
      _favorite.Add(existingFavourite);
    }
    else
    {
      var existingFavouriteItem = existingFavourite.Items.FirstOrDefault(x => x.Id == product.Id);
      if (existingFavouriteItem != null)
      {
        existingFavourite.Items.Add(product);
      }
    }
  }

  public void Delete(int productid, string userId)
  {
    var existingFavourite = TryGetByUserId(userId);
    var existingFavouriteItem = existingFavourite.Items.FirstOrDefault(x => x.Id == productid);
    if (existingFavouriteItem != null)
    {
      existingFavourite.Items.Remove(existingFavouriteItem);
    }
    
  }

  public void Clear(string userId)
  {
    var existingFavourite = TryGetByUserId(userId);
    if (existingFavourite != null) _favorite.Remove(existingFavourite);

  }
}