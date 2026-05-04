using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repository;

public interface IOrderDetailsRepository : IRepository<OrderDetails>
{
    Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId);
}
