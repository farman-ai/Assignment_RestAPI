using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repository;

public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
{
    public OrderDetailsRepository(OrderDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId)
    {
        return await DbContext.OrderDetails
            .Where(od => od.Order_Id == orderId)
            .ToListAsync();
    }

    public override async Task<OrderDetails?> UpdateAsync(OrderDetails orderDetail)
    {
        var existingOrderDetail = await DbContext.OrderDetails.FindAsync(orderDetail.Id);
        if (existingOrderDetail == null)
        {
            return null;
        }

        existingOrderDetail.Product_Id = orderDetail.Product_Id;
        existingOrderDetail.Product_name = orderDetail.Product_name;
        existingOrderDetail.Qty = orderDetail.Qty;
        existingOrderDetail.Price = orderDetail.Price;
        existingOrderDetail.Discount = orderDetail.Discount;

        await DbContext.SaveChangesAsync();
        return existingOrderDetail;
    }
}
