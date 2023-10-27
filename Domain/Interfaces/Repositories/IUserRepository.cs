using Domain.Entities;
namespace Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User, int>
{
    Task<bool> CheckUsernameExistsAsync(string username);
    Task<int> LoginAsync(string username, byte[] password);
}