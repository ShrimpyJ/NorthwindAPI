
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(int userId, string username);
}