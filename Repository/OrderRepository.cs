using HobbyGarage.Models;
namespace HobbyGarage.Repository;


public interface IOrderRepository
{
  public void Add(Order order);
}

public class OrderRepository: IOrderRepository
{
  private List<Order> _orders = new();

  public void Add(Order order)
  {
    order.Id = Guid.NewGuid();
    _orders.Add(order);
  }
}