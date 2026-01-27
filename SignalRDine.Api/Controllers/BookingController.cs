using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.BookingDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        /// <summary>
        /// Sistemdeki tüm rezervasyonları listeler.
        /// </summary>
        /// <returns>Rezervasyon listesi döner.</returns>
        [HttpGet]
        public IActionResult BookingList()
        {
            _logger.LogInformation("Rezervasyon listesi başarıyla çağrıldı.");
            var values = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }

        /// <summary>
        /// Yeni bir rezervasyon oluşturur.
        /// </summary>
        /// <param name="createBookingDto">Rezervasyon bilgileri</param>
        /// <returns>Başarılı sonuç mesajı döner.</returns>
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Rezervasyon oluşturulurken validasyon hatası gerçekleşti.");
                return BadRequest(validationResult.Errors);
            }

            var values = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(values);
            _logger.LogInformation("Yeni bir rezervasyon oluşturuldu.");
            return Ok("Rezervasyon Yapıldı");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip rezervasyonu siler.
        /// </summary>
        /// <param name="id">Silinecek rezervasyonun ID değeri</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            try
            {
                var value = _bookingService.TGetByID(id);
                _bookingService.TDelete(value);
                _logger.LogInformation("{BookingId} ID'li rezervasyon başarıyla silindi.", id);
                return Ok("Rezervasyon Silindi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{BookingId} ID'li rezervasyon silinirken bir hata oluştu!", id);
                return StatusCode(500, "Silme işlemi sırasında sunucu hatası oluştu.");
            }
        }

        /// <summary>
        /// Mevcut bir rezervasyon bilgisini günceller.
        /// </summary>
        /// <param name="updateBookingDto">Güncellenecek yeni bilgiler</param>
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            _logger.LogInformation("{BookingId} ID'li rezervasyon güncellendi.", updateBookingDto.BookingID);
            return Ok("Rezervasyon Güncellendi");
        }

        /// <summary>
        /// ID'ye göre tek bir rezervasyon getirir.
        /// </summary>
        /// <param name="id">Rezervasyon ID</param>
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }

        /// <summary>
        /// Rezervasyon durumunu 'Onaylandı' olarak işaretler.
        /// </summary>
        /// <param name="id">Rezervasyon ID</param>
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Durumu Onaylandı");
        }

        /// <summary>
        /// Rezervasyon durumunu 'İptal Edildi' olarak işaretler.
        /// </summary>
        /// <param name="id">Rezervasyon ID</param>
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon Durumu İptal Edildi");
        }

        /// <summary>
        /// Toplam rezervasyon sayısını döner.
        /// </summary>
        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount()
        {
            var values = _bookingService.TGetBookingCount();
            return Ok(values);
        }
    }
}