namespace HobbyGarage.Models;

public class Login
{
  public string Name { get; set; }
  public string Password { get; set; }
  public bool RememberMe { get; set; }
}
public class Registration
{
  public string Name { get; set; }
  public string Password { get; set; }
  public string Password2 { get; set; }
  
}