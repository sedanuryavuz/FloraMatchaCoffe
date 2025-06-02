using Flora.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            var result = _orderService.TTotalOrderCount();
            return Ok(result);
        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            var result = _orderService.TActiveOrderCount();
            return Ok(result);
        }
        [HttpGet("LastOrderTotalPrice")]
        public IActionResult LastOrderTotalPrice()
        {
            var result = _orderService.TLastOrderTotalPrice();
            return Ok(result);

        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            var result = _orderService.TTodayTotalPrice();
            return Ok(result);
        }
    }
}