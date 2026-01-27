using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.NotificationDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm bildirimleri listeler.
        /// </summary>
        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        /// <summary>
        /// Okunmamış (Status: False) bildirim sayısını döner.
        /// </summary>
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        /// <summary>
        /// Okunmamış (Status: False) tüm bildirimleri getirir.
        /// </summary>
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        /// <summary>
        /// Yeni bir bildirim oluşturur. Varsayılan durum 'Okunmadı' (false) ve tarih 'Şu an' olarak ayarlanır.
        /// </summary>
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var value = _mapper.Map<Notification>(createNotificationDto);
            value.Status = false;
            value.Date = DateTime.Now;

            _notificationService.TAdd(value);
            return Ok("Ekleme işlemi başarıyla yapıldı");
        }

        /// <summary>
        /// ID değerine göre bildirimi siler.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Silindi");
        }

        /// <summary>
        /// ID değerine göre ilgili bildirimi getirir.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            return Ok(_mapper.Map<GetByIdNotificationDto>(value));
        }

        /// <summary>
        /// Bildirim içeriğini günceller.
        /// </summary>
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _mapper.Map<Notification>(updateNotificationDto);

            _notificationService.TUpdate(value);
            return Ok("Güncelleme işlemi başarıyla yapıldı");
        }

        /// <summary>
        /// Bildirim durumunu 'Okunmadı' (false) olarak günceller.
        /// </summary>
        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme yapıldı");
        }

        /// <summary>
        /// Bildirim durumunu 'Okundu' (true) olarak günceller.
        /// </summary>
        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme yapıldı");
        }
    }
}