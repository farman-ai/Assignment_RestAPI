using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.API.Controllers;

[ApiController]
[Route("api/order-details")]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailsService _orderDetailsService;

    public OrderDetailsController(IOrderDetailsService orderDetailsService)
    {
        _orderDetailsService = orderDetailsService;
    }

    [HttpGet("order/{orderId:int}")]
    public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetailsByOrderId(int orderId)
    {
        var orderDetails = await _orderDetailsService.GetOrderDetailsByOrderIdAsync(orderId);
        return Ok(orderDetails);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDetails>> GetOrderDetailById(int id)
    {
        var orderDetail = await _orderDetailsService.GetOrderDetailByIdAsync(id);
        return orderDetail == null ? NotFound() : Ok(orderDetail);
    }

    [HttpPost("order/{orderId:int}")]
    public async Task<ActionResult<OrderDetails>> SaveOrderDetail(int orderId, [FromBody] OrderDetailsRequestModel model)
    {
        var orderDetail = await _orderDetailsService.SaveOrderDetailAsync(orderId, model);
        return CreatedAtAction(nameof(GetOrderDetailById), new { id = orderDetail.Id }, orderDetail);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] OrderDetailsRequestModel model)
    {
        var updated = await _orderDetailsService.UpdateOrderDetailAsync(id, model);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        var deleted = await _orderDetailsService.DeleteOrderDetailAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
