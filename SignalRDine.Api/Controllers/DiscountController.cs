using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.DiscountDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm indirim tekliflerini listeler.
        /// </summary>
        /// <returns>İndirim bilgilerinden oluşan bir liste döner.</returns>
        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }

        /// <summary>
        /// Yeni bir indirim teklifi oluşturur. Varsayılan durum 'Pasif' (false) olarak ayarlanır.
        /// </summary>
        /// <param name="createDiscountDto">Eklenecek indirim bilgileri</param>
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            value.Status = false;
            _discountService.TAdd(value);
            return Ok("İndirim Bilgisi Eklendi");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip indirim teklifini siler.
        /// </summary>
        /// <param name="id">İndirim ID</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("İndirim Bilgisi Silindi");
        }

        /// <summary>
        /// ID değerine göre ilgili indirim teklifini getirir.
        /// </summary>
        /// <param name="id">İndirim ID</param>
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }

        /// <summary>
        /// Mevcut bir indirim teklifini günceller.
        /// </summary>
        /// <param name="updateDiscountDto">Güncellenecek indirim verileri</param>
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            value.Status = false;
            _discountService.TUpdate(value);
            return Ok("İndirim Bilgisi Güncellendi");
        }

        /// <summary>
        /// İndirim teklifini aktif hale getirir.
        /// </summary>
        /// <param name="id">İndirim ID</param>
        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("Ürün İndirimi Aktif Hale Getirildi");
        }

        /// <summary>
        /// İndirim teklifini pasif hale getirir.
        /// </summary>
        /// <param name="id">İndirim ID</param>
        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok("Ürün İndirimi Pasif Hale Getirildi");
        }

        /// <summary>
        /// Sadece aktif durumda olan indirim tekliflerini listeler.
        /// </summary>
        /// <returns>Aktif indirim listesi döner.</returns>
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            var values = _discountService.TGetListByStatusTrue();
            return Ok(_mapper.Map<List<ResultDiscountDto>>(values));
        }
    }
}