using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<IdNamePair<string>>> GetIdNamePairsAsync()
    {
        return await _customerRepository.GetIdNamePairsAsync();
    }

    public async Task<string> AddAsync(Customer customer)
    {
        string customerId = await _customerRepository.AddAsync(customer);
        return customerId;
    }

    public async Task<int> UpdateAsync(Customer customer)
    {
        return await _customerRepository.UpdateAsync(customer);
    }

    public async Task<int> DeleteAsync(string id)
    {
        return await _customerRepository.DeleteAsync(id);
    }

    public async Task<Customer?> GetByIdAsync(string id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync();
    }
}