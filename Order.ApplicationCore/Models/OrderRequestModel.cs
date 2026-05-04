namespace Order.ApplicationCore.Models;

public class OrderRequestModel
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int PaymentMethodId { get; set; }
    public string PaymentName { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string ShippingMethod { get; set; } = string.Empty;
    public decimal BillAmount { get; set; }
    public string Order_Status { get; set; } = "Pending";
    public List<OrderDetailsRequestModel> OrderDetails { get; set; } = new();
}

public class OrderDetailsRequestModel
{
    public int Id { get; set; }
    public int Product_Id { get; set; }
    public string Product_name { get; set; } = string.Empty;
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}
