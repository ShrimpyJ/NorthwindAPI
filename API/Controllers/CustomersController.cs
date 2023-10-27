using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("get-names")]
    public async Task<IActionResult> GetIdNamePairs()
    {
        var customers = await _customerService.GetIdNamePairsAsync();
        return Ok(customers);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Customer customer)
    {
        await _customerService.AddAsync(customer);
        return Ok(customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Customer customer)
    {
        if (id != customer.Id) return BadRequest("Mismatched ID and customer data.");
        var rowsAffected = await _customerService.UpdateAsync(customer);
        return Ok(rowsAffected);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var rowsAffected = await _customerService.DeleteAsync(id);
        return Ok(rowsAffected);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        return Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customer = await _customerService.GetAllAsync();
        return Ok(customer);
    }
}