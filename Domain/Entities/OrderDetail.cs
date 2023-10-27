namespace Domain.Entities;

public class OrderDetail
{
    // Required columns
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public double Discount { get; set; }

    // Optional columns
    public bool? IsBackorder { get; set; }
    public DateTime? BackorderDate { get; set; }
    public DateTime? BackorderFulfilledDate { get; set; }
    public bool? Cancelled { get; set; }
    public DateTime? CancellationDate { get; set; }
}