using API;
using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services;

public class OrderService : IOrderService
{
    private readonly IInventoryService _inventoryService;
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository, IInventoryService inventoryService)
    {
        _orderRepository = orderRepository;
        _inventoryService = inventoryService;
    }

    public async Task<int> PlaceOrderAsync(int userId, OrderRequest orderRequest)
    {
        // Get inventory stocks
        var stocks = await _inventoryService.CheckStock(orderRequest.Products);

        // Get backorders

        // Fulfill full orders

        // Fulfill partial orders

        return 0;
    }

    public async Task<int> UpdateAsync(Order order)
    {
        return await _orderRepository.UpdateAsync(order);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _orderRepository.DeleteAsync(id);
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<List<Order>> GetUserOrders(int userId)
    {
        return await _orderRepository.GetUserOrders(userId);
    }

    public async Task<List<dynamic>> GetUserOrdersPreview(int userId)
    {
        return await _orderRepository.GetUserOrdersPreview(userId);
    }

}