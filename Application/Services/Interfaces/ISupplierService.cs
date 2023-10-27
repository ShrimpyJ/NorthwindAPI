
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ISupplierService
{
    Task<Supplier> AddAsync(Supplier supplier);
    Task<int> UpdateAsync(Supplier supplier);
    Task<int> DeleteAsync(int id);
    Task<Supplier?> GetByIdAsync(int id);
    Task<List<Supplier>> GetAllAsync();
}