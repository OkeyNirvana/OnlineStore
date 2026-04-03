namespace HobbyGarage.Models;

public class Comparison
{
  public string UserId { get; set; }
  public Guid Id { get; set; }
  public List<Product> Items { get; set; }
}