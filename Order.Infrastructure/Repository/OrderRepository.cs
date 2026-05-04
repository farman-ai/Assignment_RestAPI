using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repository;

public class OrderRepository : Repository<OrderHistory>, IOrderRepository
{
    public OrderRepository(OrderDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<OrderHistory>> GetAllAsync()
    {
        return await DbContext.Orders
            .Include(o => o.OrderDetails)
            .ToListAsync();
    }

    public override async Task<OrderHistory?> GetByIdAsync(int id)
    {
        return await DbContext.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<OrderHistory>> GetOrdersByCustomerIdAsync(int customerId)
    {
        return await DbContext.Orders
            .Include(o => o.OrderDetails)
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
    }

    public override async Task<OrderHistory?> UpdateAsync(OrderHistory order)
    {
        var existingOrder = await DbContext.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.Id == order.Id);

        if (existingOrder == null)
        {
            return null;
        }

        DbContext.Entry(existingOrder).CurrentValues.SetValues(order);
        DbContext.OrderDetails.RemoveRange(existingOrder.OrderDetails);
        existingOrder.OrderDetails = order.OrderDetails;

        await DbContext.SaveChangesAsync();
        return existingOrder;
    }
}
