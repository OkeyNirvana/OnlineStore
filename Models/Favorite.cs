namespace HobbyGarage.Models;

public class Favorite
{
  public List<Product> Items { get; set; }
  public string? UserId { get; set; }
  public Guid Id { get; set; }
}