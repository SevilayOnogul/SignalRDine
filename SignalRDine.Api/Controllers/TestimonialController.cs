using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.TestimonialDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm müşteri yorumlarını listeler.
        /// </summary>
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetListAll();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
        }

        /// <summary>
        /// Yeni bir müşteri yorumu ekler.
        /// </summary>
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);
            return Ok("Müşteri Yorumu Başarıyla Eklendi");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip müşteri yorumunu siler.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorumu Başarıyla Silindi");
        }

        /// <summary>
        /// ID değerine göre müşteri yorumunu getirir.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(_mapper.Map<GetTestimonialDto>(value));
        }

        /// <summary>
        /// Müşteri yorumunu günceller.
        /// </summary>
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Müşteri Yorumu Başarıyla Güncellendi");
        }

        /// <summary>
        /// Sadece aktif olan (Status: True) müşteri yorumlarını listeler.
        /// </summary>
        [HttpGet("GetActiveTestimonials")]
        public IActionResult GetActiveTestimonials()
        {
            var values = _testimonialService.TGetListAll().Where(x => x.Status == true).ToList();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
        }

        /// <summary>
        /// Müşteri yorumunu aktif hale getirir.
        /// </summary>
        [HttpGet("ChangeStatusTrue/{id}")]
        public IActionResult ChangeStatusTrue(int id)
        {
            var value = _testimonialService.TGetByID(id);
            value.Status = true;
            _testimonialService.TUpdate(value);
            return Ok("Referans Durumu Aktif Yapıldı");
        }

        /// <summary>
        /// Müşteri yorumunu pasif hale getirir.
        /// </summary>
        [HttpGet("ChangeStatusFalse/{id}")]
        public IActionResult ChangeStatusFalse(int id)
        {
            var value = _testimonialService.TGetByID(id);
            value.Status = false;
            _testimonialService.TUpdate(value);
            return Ok("Referans Durumu Pasif Yapıldı");
        }
    }
}