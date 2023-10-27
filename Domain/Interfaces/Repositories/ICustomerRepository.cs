using Domain.ValueObjects;
using Domain.Entities;

namespace Domain.Interfaces;

public interface ICustomerRepository : IGenericRepository<Customer, string>
{
    Task<List<IdNamePair<string>>> GetIdNamePairsAsync();
}