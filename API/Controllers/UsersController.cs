using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User user)
    {
        if (id != user.Id) return BadRequest("Mismatched ID and user data.");
        var rowsAffected = await _userService.UpdateAsync(user);
        return Ok(rowsAffected);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var rowsAffected = await _userService.DeleteAsync(id);
        return Ok(rowsAffected);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }

/*    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = await _userService.GetAllAsync();
        return Ok(user);
    }
*/
}