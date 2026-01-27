using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;

namespace SignalRDine.Api.Controllers
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

        /// <summary>
        /// Sistemdeki toplam sipariş sayısını döner.
        /// </summary>
        [HttpGet]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        /// <summary>
        /// Şu an aktif olan (hazırlanan/açık) sipariş sayısını döner.
        /// </summary>
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        /// <summary>
        /// Son verilen siparişin tutarını döner.
        /// </summary>
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }

        /// <summary>
        /// Bugün yapılan toplam satış tutarını döner.
        /// </summary>
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok(_orderService.TTodayTotalPrice());
        }

        /// <summary>
        /// Bugün kasaya giren nakit miktarını döner.
        /// </summary>
        [HttpGet("TodayCash")]
        public IActionResult TodayCash()
        {
            return Ok(_orderService.TTodayCash());
        }
    }
}