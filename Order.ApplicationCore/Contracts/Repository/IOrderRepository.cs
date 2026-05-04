using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repository;

public interface IOrderRepository : IRepository<OrderHistory>
{
    Task<IEnumerable<OrderHistory>> GetOrdersByCustomerIdAsync(int customerId);
}
