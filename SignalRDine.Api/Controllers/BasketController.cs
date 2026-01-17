using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.BasketDto;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            var values = _basketService.TGetBasketListByMenuTableWithProductName(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            _basketService.TAddBasketWithProductPrice(createBasketDto);
            return Ok("Ürün başarıyla sepete eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value=_basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}
