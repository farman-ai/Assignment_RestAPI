using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderDetailsService
{
    Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId);
    Task<OrderDetails?> GetOrderDetailByIdAsync(int id);
    Task<OrderDetails> SaveOrderDetailAsync(int orderId, OrderDetailsRequestModel model);
    Task<bool> UpdateOrderDetailAsync(int id, OrderDetailsRequestModel model);
    Task<bool> DeleteOrderDetailAsync(int id);
}
