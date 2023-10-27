using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository : IGenericRepository<Product, int>
{
    Task<List<dynamic>> GetProductsAsync();
    Task<int> ReorderProductAsync(int id, int unitsToOrder);
}