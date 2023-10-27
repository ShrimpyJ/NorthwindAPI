
using Domain.Entities;
using Application.DTOs;
using API;

namespace Application.Services.Interfaces;

public interface IOrderService
{
    Task<int> PlaceOrderAsync(int userId, OrderRequest orderRequest);
    Task<int> UpdateAsync(Order order);
    Task<int> DeleteAsync(int id);
    Task<Order?> GetByIdAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task<List<Order>> GetUserOrders(int userId);
    Task<List<dynamic>> GetUserOrdersPreview(int userId);
}