using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.MessageDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm mesajları listeler.
        /// </summary>
        /// <returns>Mesaj listesi döner.</returns>
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
        }

        /// <summary>
        /// Yeni bir mesaj oluşturur.
        /// </summary>
        /// <param name="createMessageDto">Mesaj bilgileri</param>
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(value);
            return Ok("Mesaj Başarılı Şekilde Eklendi");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip mesajı siler.
        /// </summary>
        /// <param name="id">Mesaj ID</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Mesaj Silindi");
        }

        /// <summary>
        /// Mesaj içeriğini günceller.
        /// </summary>
        /// <param name="updateMessageDto">Güncellenecek mesaj verileri</param>
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Mesajınız Güncellendi");
        }

        /// <summary>
        /// ID değerine göre ilgili mesajı getirir.
        /// </summary>
        /// <param name="id">Mesaj ID</param>
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value));
        }
    }
}