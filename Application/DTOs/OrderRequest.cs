using Domain.ValueObjects;

namespace Application.DTOs;

public class OrderRequest
{
    public List<OrderItem> Products { get; set; }
    //public string CustomerId { get; set; }
    public DateTime RequiredDate { get; set; }
    public int ShipVia { get; set; }
}