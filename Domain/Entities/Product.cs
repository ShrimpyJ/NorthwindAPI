namespace Domain.Entities;

public class Product
{
    // Required columns
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Discontinued { get; set; }

    // Optional columns
    public int? SupplierId { get; set; }
    public int? CategoryId { get; set; }
    public string? QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitsInStock { get; set; }
    public int? UnitsOnOrder { get; set; }
    public int? ReorderLevel { get; set; }
}