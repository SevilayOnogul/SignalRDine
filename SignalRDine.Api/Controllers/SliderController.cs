using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.FeatureDto;
using SignalRDine.DtoLayer.SliderDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        /// <summary>
        /// Ana sayfadaki tüm slider (öne çıkan alan) içeriklerini listeler.
        /// </summary>
        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        /// <summary>
        /// Yeni bir slider içeriği oluşturur.
        /// </summary>
        /// <param name="createSliderDto">Eklenecek slider bilgileri</param>
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(value);
            return Ok("Öne Çıkan Alan Bilgisi Eklendi");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip slider içeriğini siler.
        /// </summary>
        /// <param name="id">Silinecek slider ID</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Öne Çıkan Alan Bilgisi Silindi");
        }

        /// <summary>
        /// ID değerine göre ilgili slider bilgisini getirir.
        /// </summary>
        /// <param name="id">Slider ID</param>
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            return Ok(_mapper.Map<GetByIdSliderDto>(value));
        }

        /// <summary>
        /// Mevcut bir slider içeriğini günceller.
        /// </summary>
        /// <param name="updateSliderDto">Güncellenecek slider verileri</param>
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var value = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(value);
            return Ok("Öne Çıkan Alan Bilgisi Güncellendi");
        }
    }
}