
using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IInventoryService
{
    Task<List<StockStatus>> CheckStock(List<OrderItem> items);
    Task ReduceStock(List<OrderItem> items);
}