using Application.Services.Interfaces;
using System;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using System.Security.Cryptography;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<bool> Register(string username, string password)
    {
        // Ensure username is not taken
        bool userExists = await _userRepository.CheckUsernameExistsAsync(username);
        if (userExists)
        {
            return false;
        }

        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        User user = new User { Username = username, Password = bytes };
        await _userRepository.AddAsync(user);

        return true;
    }

    public async Task<string?> Authenticate(string username, string password)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        User user = new User { Username = username, Password = bytes };
        int userId = await _userRepository.LoginAsync(username, bytes);
        if (userId > 0) return _tokenService.GenerateJwtToken(userId, username);
        return null;
    }
}