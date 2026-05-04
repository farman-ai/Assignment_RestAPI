namespace Order.ApplicationCore.Entities;

public class OrderDetails
{
    public int Id { get; set; }
    public int Order_Id { get; set; }
    public int Product_Id { get; set; }
    public string Product_name { get; set; } = string.Empty;
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }

    public OrderHistory? Order { get; set; }
}
