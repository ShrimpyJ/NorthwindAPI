namespace Domain.ValueObjects;

public class StockStatus
{
    public StockStatus(int productId, int requestedQuantity, int availableQuantity)
    {
        ProductId = productId;
        RequestedQuantity = requestedQuantity;
        AvailableQuantity = availableQuantity;
        IsAvailable = RequestedQuantity <= AvailableQuantity;
        BackorderQuantity = IsAvailable ? 0 : RequestedQuantity - AvailableQuantity;
    }

    public int ProductId { get; set; }
    public int RequestedQuantity { get; set; }
    public int AvailableQuantity { get; set; }
    public int FulfillableQuantity { get; set; }
    public bool IsAvailable { get; set; }
    public int BackorderQuantity { get; set; }
}