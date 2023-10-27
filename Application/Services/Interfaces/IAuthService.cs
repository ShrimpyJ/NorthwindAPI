
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IAuthService
{
    Task<bool> Register(string username, string password);
    Task<string?> Authenticate(string username, string password);
}