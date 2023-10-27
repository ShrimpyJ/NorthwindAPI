using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services.Interfaces;

public interface ICustomerService
{
    Task<List<IdNamePair<string>>> GetIdNamePairsAsync();
    Task<string> AddAsync(Customer customer);
    Task<int> UpdateAsync(Customer customer);
    Task<int> DeleteAsync(string id);
    Task<Customer?> GetByIdAsync(string id);
    Task<List<Customer>> GetAllAsync();
}