using Domain.ValueObjects;
using Domain.Interfaces;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IProductRepository _productRepository;

    public InventoryService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<StockStatus>> CheckStock(List<OrderItem> items)
    {
        var stocks = new List<StockStatus>();

        foreach(var item in items)
        {
            if (item.Quantity <= 0)
            {
                throw new InvalidOrderQuantityException($"Invalid quantity {item.Quantity} for Product ID {item.Id}");
            }
            var product = await _productRepository.GetByIdAsync(item.Id);
            var stock = new StockStatus(item.Id, item.Quantity, (int)product.UnitsInStock);
            stocks.Add(stock);
        }

        return stocks;
    }

    public async Task ReduceStock(List<OrderItem> orderItems)
    {
        foreach(var item in orderItems)
        {
        }
    }
}