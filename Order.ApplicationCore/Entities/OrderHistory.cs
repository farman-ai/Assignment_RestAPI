namespace Order.ApplicationCore.Entities;

public class OrderHistory
{
    public int Id { get; set; }
    public DateTime Order_Date { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int PaymentMethodId { get; set; }
    public string PaymentName { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string ShippingMethod { get; set; } = string.Empty;
    public decimal BillAmount { get; set; }
    public string Order_Status { get; set; } = string.Empty;

    public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}
