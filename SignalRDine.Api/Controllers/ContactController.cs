using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.ContactDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm iletişim bilgilerini listeler.
        /// </summary>
        /// <returns>İletişim bilgilerini içeren liste döner.</returns>
        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(value);
        }

        /// <summary>
        /// Yeni bir iletişim bilgisi kaydı oluşturur.
        /// </summary>
        /// <param name="createContactDto">Eklenecek iletişim verileri</param>
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);
            return Ok("İletişim Bilgisi Eklendi");
        }

        /// <summary>
        /// Mevcut iletişim bilgisini günceller.
        /// </summary>
        /// <param name="updateContactDto">Güncellenecek yeni veriler</param>
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("İletişim Bilgisi Güncellendi");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip iletişim bilgisini siler.
        /// </summary>
        /// <param name="id">Silinecek iletişim kaydının ID değeri</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("İletişim Bilgisi Silindi");
        }

        /// <summary>
        /// ID değerine göre belirli bir iletişim bilgisini getirir.
        /// </summary>
        /// <param name="id">İletişim ID</param>
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(_mapper.Map<GetContactDto>(value));
        }
    }
}