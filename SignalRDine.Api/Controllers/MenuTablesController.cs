using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.MenuTableDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        /// <summary>
        /// Toplam masa sayısını döner.
        /// </summary>
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

        /// <summary>
        /// Tüm masaları listeler.
        /// </summary>
        /// <returns>Masa listesi döner.</returns>
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMenuTableDto>>(values));
        }

        /// <summary>
        /// Yeni bir masa oluşturur. Varsayılan durum 'Boş/Pasif' (false) olarak ayarlanır.
        /// </summary>
        /// <param name="createMenuTableDto">Masa bilgileri</param>
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            var value = _mapper.Map<MenuTable>(createMenuTableDto);
            value.Status = false;

            _menuTableService.TAdd(value);
            return Ok("Masa Başarılı Bir Şeklinde Eklendi");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip masayı siler.
        /// </summary>
        /// <param name="id">Masa ID</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            _menuTableService.TDelete(value);
            return Ok("Masa Silindi");
        }

        /// <summary>
        /// Masa bilgilerini günceller.
        /// </summary>
        /// <param name="updateMenuTableDto">Güncellenecek masa verileri</param>
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            var value = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(value);
            return Ok("Masa Bilgisi Güncellendi");
        }

        /// <summary>
        /// ID değerine göre ilgili masa bilgilerini getirir.
        /// </summary>
        /// <param name="id">Masa ID</param>
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            return Ok(_mapper.Map<GetMenuTableDto>(value));
        }

        /// <summary>
        /// Masa durumunu 'Dolu/Aktif' (true) olarak günceller.
        /// </summary>
        /// <param name="id">Masa ID</param>
        [HttpGet("ChangeMenuTableStatusToTrue")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
            _menuTableService.TChangeMenuTableStatusToTrue(id);
            return Ok("İşlem başarılı");
        }

        /// <summary>
        /// Masa durumunu 'Boş/Pasif' (false) olarak günceller.
        /// </summary>
        /// <param name="id">Masa ID</param>
        [HttpGet("ChangeMenuTableStatusToFalse")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            _menuTableService.TChangeMenuTableStatusToFalse(id);
            return Ok("İşlem başarılı");
        }
    }
}