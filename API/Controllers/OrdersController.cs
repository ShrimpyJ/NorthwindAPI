using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("place-order")]
    public async Task<IActionResult> PlaceOrder(OrderRequest orderRequest)
    {
        int userId = 1;

        try
        {
            await _orderService.PlaceOrderAsync(userId, orderRequest);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //[Authorize]
    [HttpPost]
    public async Task<IActionResult> Add(OrderRequest orderRequest)
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userIdClaim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim is null) return Unauthorized("Invalid user or request.");
        int userId = int.Parse(userIdClaim.Value);

        try
        {
            int orderId = await _orderService.PlaceOrderAsync(userId, orderRequest);
            return Ok(orderId);
        }
        catch (InvalidEmployeeException)
        {
            return Unauthorized("User placing order is not an employee.");
        }
        catch (InvalidRequiredDateException)
        {
            return BadRequest("Required date cannot be in the past.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(orders);
    }

    [Authorize]
    [HttpGet("user")]
    public async Task<IActionResult> GetUserOrders()
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userIdClaim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim is null) return Unauthorized("Invalid user or request.");
        int userId = int.Parse(userIdClaim.Value);

        var orders = await _orderService.GetUserOrders(userId);
        return Ok(new { Success = true, Data = orders });
    }

    [Authorize]
    [HttpGet("user-preview")]
    public async Task<IActionResult> GetUserOrdersPreview()
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var userIdClaim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim is null) return Unauthorized("Invalid user or request.");
        int userId = int.Parse(userIdClaim.Value);

        var orderPreviews = await _orderService.GetUserOrdersPreview(userId);
        return Ok(new { Success = true, Data = orderPreviews });
    }
}