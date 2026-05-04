using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.Infrastructure.Services;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;

    public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
    {
        _orderDetailsRepository = orderDetailsRepository;
    }

    public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId)
    {
        return await _orderDetailsRepository.GetOrderDetailsByOrderIdAsync(orderId);
    }

    public async Task<OrderDetails?> GetOrderDetailByIdAsync(int id)
    {
        return await _orderDetailsRepository.GetByIdAsync(id);
    }

    public async Task<OrderDetails> SaveOrderDetailAsync(int orderId, OrderDetailsRequestModel model)
    {
        var orderDetail = MapToOrderDetail(model);
        orderDetail.Order_Id = orderId;

        return await _orderDetailsRepository.AddAsync(orderDetail);
    }

    public async Task<bool> UpdateOrderDetailAsync(int id, OrderDetailsRequestModel model)
    {
        var orderDetail = MapToOrderDetail(model);
        orderDetail.Id = id;

        return await _orderDetailsRepository.UpdateAsync(orderDetail) != null;
    }

    public async Task<bool> DeleteOrderDetailAsync(int id)
    {
        return await _orderDetailsRepository.DeleteAsync(id);
    }

    private static OrderDetails MapToOrderDetail(OrderDetailsRequestModel model)
    {
        return new OrderDetails
        {
            Product_Id = model.Product_Id,
            Product_name = model.Product_name,
            Qty = model.Qty,
            Price = model.Price,
            Discount = model.Discount
        };
    }
}
