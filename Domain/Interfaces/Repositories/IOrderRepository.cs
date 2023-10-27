using Domain.Entities;
namespace Domain.Interfaces;

public interface IOrderRepository : IGenericRepository<Order, int>
{
    Task<List<Order>> GetUserOrders(int userId);
    Task<dynamic> GetUserOrdersPreview(int userId);
    Task<int> GetEmployeeId(int userId);
}