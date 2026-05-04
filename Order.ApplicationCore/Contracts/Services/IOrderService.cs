using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderHistory>> GetAllOrdersAsync();
    Task<OrderHistory?> GetOrderByIdAsync(int id);
    Task<IEnumerable<OrderHistory>> GetOrdersByCustomerIdAsync(int customerId);
    Task<OrderHistory> SaveOrderAsync(OrderRequestModel model);
    Task<bool> UpdateOrderAsync(int id, OrderRequestModel model);
    Task<bool> DeleteOrderAsync(int id);
}
