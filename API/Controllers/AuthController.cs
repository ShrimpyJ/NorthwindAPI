using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginRequest request)
    {
        bool success = await _authService.Register(request.Username, request.Password);
        if (!success) return Unauthorized("Username already in use.");
        return Ok(new { Success = true, Message = $"{request.Username} created" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        string? token = await _authService.Authenticate(request.Username, request.Password);
        if (string.IsNullOrEmpty(token)) return Unauthorized();
        return Ok(new { Success = true, Token = token });
    }
}