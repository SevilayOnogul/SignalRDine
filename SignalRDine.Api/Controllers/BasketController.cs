using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.BasketDto;
using SignalRDine.DtoLayer.BookingDto;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        /// <summary>
        /// Masa numarasına göre sepet içeriğini getirir.
        /// </summary>
        /// <param name="id">Masa (MenuTable) ID değeri</param>
        [HttpGet]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        /// <summary>
        /// Masa numarasına göre ürün adlarını da içerecek şekilde sepet listesini getirir.
        /// </summary>
        /// <param name="id">Masa (MenuTable) ID değeri</param>
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            var values = _basketService.TGetBasketListByMenuTableWithProductName(id);
            return Ok(values);
        }

        /// <summary>
        /// Sepete yeni bir ürün ekler (Ürün fiyatı otomatik hesaplanır).
        /// </summary>
        /// <param name="createBasketDto">Eklenecek sepet kalemi bilgileri</param>
        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            _basketService.TAddBasketWithProductPrice(createBasketDto);
            return Ok("Ürün başarıyla sepete eklendi.");
        }

        /// <summary>
        /// Sepetteki belirli bir ürünü (satırı) siler.
        /// </summary>
        /// <param name="id">Sepet (Basket) öğesi ID değeri</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}