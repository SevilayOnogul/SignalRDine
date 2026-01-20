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

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetListAll();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);
            return Ok("Müşteri Yorumu Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorumu Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(_mapper.Map<GetTestimonialDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Müşteri Yorumu Başarıyla Güncellendi");
        }
        [HttpGet("GetActiveTestimonials")]
        public IActionResult GetActiveTestimonials()
        {
            var values = _testimonialService.TGetListAll().Where(x => x.Status == true).ToList();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
        }

        [HttpGet("ChangeStatusTrue/{id}")]
        public IActionResult ChangeStatusTrue(int id)
        {
            var value = _testimonialService.TGetByID(id);
            value.Status = true;
            _testimonialService.TUpdate(value);
            return Ok("Referans Durumu Aktif Yapıldı");
        }
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