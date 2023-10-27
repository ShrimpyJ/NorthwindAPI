using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SuppliersController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(Supplier supplier)
    {
        await _supplierService.AddAsync(supplier);
        return Ok(supplier);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Supplier supplier)
    {
        if (id != supplier.Id) return BadRequest("Mismatched ID and supplier data.");
        var rowsAffected = await _supplierService.UpdateAsync(supplier);
        return Ok(rowsAffected);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var rowsAffected = await _supplierService.DeleteAsync(id);
        return Ok(rowsAffected);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var supplier = await _supplierService.GetByIdAsync(id);
        return Ok(supplier);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var supplier = await _supplierService.GetAllAsync();
        return Ok(supplier);
    }
}