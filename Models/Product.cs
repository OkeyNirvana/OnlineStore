using Microsoft.VisualBasic.CompilerServices;

namespace HobbyGarage.Models;

public class Product
{
    public int Id  { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Cost { get; set; }

    public string Description { get; set; } = string.Empty;

    public string PhotoPath = "/img/cart.png";
    
    public Product()
    { }
    
    public Product(int id, string name, decimal cost, string description)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Description = description;
    }
}
