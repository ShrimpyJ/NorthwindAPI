using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _productRepository.AddAsync(product);
        return product;
    }

    public async Task<int> UpdateAsync(Product product)
    {
        return await _productRepository.UpdateAsync(product);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _productRepository.DeleteAsync(id);
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<List<dynamic>> GetProductsAsync()
    {
        var products = await _productRepository.GetProductsAsync();
        return products;
    }

    public async Task<int> ReorderProductAsync(int id, int unitsToOrder)
    {
        return await _productRepository.ReorderProductAsync(id, unitsToOrder);
    }
}