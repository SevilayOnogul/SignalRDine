using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.AboutDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        /// <summary>
        /// Hakkımda bölümündeki tüm içerikleri listeler.
        /// </summary>
        /// <returns>Hakkımda bilgilerinden oluşan bir liste döner.</returns>
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }

        /// <summary>
        /// Yeni bir hakkımda içeriği oluşturur.
        /// </summary>
        /// <param name="createAboutDto">Eklenecek içerik bilgileri</param>
        /// <returns>Başarılı işlem mesajı döner.</returns>
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(value);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip hakkımda içeriğini siler.
        /// </summary>
        /// <param name="id">Silinecek içeriğin ID değeri</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda Alanı Silindi");
        }

        /// <summary>
        /// Mevcut bir hakkımda içeriğini günceller.
        /// </summary>
        /// <param name="updateAboutDto">Güncellenecek yeni bilgiler</param>
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok("Hakkımda Alanı Güncellendi");
        }

        /// <summary>
        /// ID değerine göre ilgili hakkımda içeriğini getirir.
        /// </summary>
        /// <param name="id">Hakkımda ID</param>
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }
    }
}