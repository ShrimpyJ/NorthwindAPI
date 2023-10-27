using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<Supplier> AddAsync(Supplier supplier)
    {
        await _supplierRepository.AddAsync(supplier);
        return supplier;
    }

    public async Task<int> UpdateAsync(Supplier supplier)
    {
        return await _supplierRepository.UpdateAsync(supplier);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _supplierRepository.DeleteAsync(id);
    }

    public async Task<Supplier?> GetByIdAsync(int id)
    {
        return await _supplierRepository.GetByIdAsync(id);
    }

    public async Task<List<Supplier>> GetAllAsync()
    {
        return await _supplierRepository.GetAllAsync();
    }
}