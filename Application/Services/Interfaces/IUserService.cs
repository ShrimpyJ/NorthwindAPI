
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IUserService
{
    Task<int> UpdateAsync(User supplier);
    Task<int> DeleteAsync(int id);
    Task<User?> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
}