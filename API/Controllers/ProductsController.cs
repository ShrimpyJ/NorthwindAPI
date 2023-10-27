using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        await _productService.AddAsync(product);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        if (id != product.Id) return BadRequest("Mismatched ID and product data.");
        var rowsAffected = await _productService.UpdateAsync(product);
        return Ok(rowsAffected);
    }

    [HttpPost("reorder")]
    public async Task<IActionResult> Reorder(int id, int unitsToOrder)
    {
        if (unitsToOrder <= 0) return BadRequest("Amount to order must a positive number.");
        var rowsAffected = await _productService.ReorderProductAsync(id, unitsToOrder);
        return Ok(rowsAffected);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var rowsAffected = await _productService.DeleteAsync(id);
        return Ok(rowsAffected);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(new CommonResult<dynamic> { IsSuccess = true, Data = products });
    }
}