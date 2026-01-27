using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.SocialMediaDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm sosyal medya hesap bilgilerini listeler.
        /// </summary>
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }

        /// <summary>
        /// Yeni bir sosyal medya hesap bilgisi ekler.
        /// </summary>
        /// <param name="createSocialMediaDto">Eklenecek sosyal medya bilgileri</param>
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(value);
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip sosyal medya bilgisini siler.
        /// </summary>
        /// <param name="id">Sosyal Medya ID</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }

        /// <summary>
        /// ID değerine göre ilgili sosyal medya bilgisini getirir.
        /// </summary>
        /// <param name="id">Sosyal Medya ID</param>
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(_mapper.Map<GetSocialMediaDto>(value));
        }

        /// <summary>
        /// Sosyal medya hesap bilgilerini günceller.
        /// </summary>
        /// <param name="updateSocialMediaDto">Güncellenecek sosyal medya verileri</param>
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(value);
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }
    }
}