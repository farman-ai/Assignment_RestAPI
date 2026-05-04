using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderHistory>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<OrderHistory?> GetOrderByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<OrderHistory>> GetOrdersByCustomerIdAsync(int customerId)
    {
        return await _orderRepository.GetOrdersByCustomerIdAsync(customerId);
    }

    public async Task<OrderHistory> SaveOrderAsync(OrderRequestModel model)
    {
        var order = MapToOrder(model);
        order.Order_Date = DateTime.UtcNow;
        order.Order_Status = string.IsNullOrWhiteSpace(model.Order_Status) ? "Pending" : model.Order_Status;

        return await _orderRepository.AddAsync(order);
    }

    public async Task<bool> UpdateOrderAsync(int id, OrderRequestModel model)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(id);
        if (existingOrder == null)
        {
            return false;
        }

        var order = MapToOrder(model);
        order.Id = id;
        order.Order_Date = existingOrder.Order_Date;

        await _orderRepository.UpdateAsync(order);
        return true;
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        return await _orderRepository.DeleteAsync(id);
    }

    private static OrderHistory MapToOrder(OrderRequestModel model)
    {
        return new OrderHistory
        {
            CustomerId = model.CustomerId,
            CustomerName = model.CustomerName,
            PaymentMethodId = model.PaymentMethodId,
            PaymentName = model.PaymentName,
            ShippingAddress = model.ShippingAddress,
            ShippingMethod = model.ShippingMethod,
            BillAmount = model.BillAmount,
            Order_Status = model.Order_Status,
            OrderDetails = model.OrderDetails.Select(od => new OrderDetails
            {
                Id = od.Id,
                Product_Id = od.Product_Id,
                Product_name = od.Product_name,
                Qty = od.Qty,
                Price = od.Price,
                Discount = od.Discount
            }).ToList()
        };
    }
}
