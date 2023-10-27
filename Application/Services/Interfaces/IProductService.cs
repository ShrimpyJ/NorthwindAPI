
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IProductService
{
    Task<Product> AddAsync(Product product);
    Task<int> UpdateAsync(Product product);
    Task<int> DeleteAsync(int id);
    Task<Product?> GetByIdAsync(int id);
    Task<List<dynamic>> GetProductsAsync();
    Task<int> ReorderProductAsync(int id, int unitsToOrder);
}