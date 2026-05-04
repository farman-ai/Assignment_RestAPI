using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderHistory>>> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderHistory>> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpGet("customer/{customerId:int}")]
    public async Task<ActionResult<IEnumerable<OrderHistory>>> GetOrderByCustomerId(int customerId)
    {
        var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<ActionResult<OrderHistory>> SaveOrder([FromBody] OrderRequestModel model)
    {
        var order = await _orderService.SaveOrderAsync(model);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderRequestModel model)
    {
        var updated = await _orderService.UpdateOrderAsync(id, model);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var deleted = await _orderService.DeleteOrderAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
