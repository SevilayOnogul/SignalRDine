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

        [HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}

		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values=_menuTableService.TGetListAll();
			return Ok(_mapper.Map<List<ResultMenuTableDto>>(values));
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			var value=_mapper.Map<MenuTable>(createMenuTableDto);
			value.Status = false;

			_menuTableService.TAdd(value);
			return Ok("Masa Başarılı Bir Şeklinde Eklendi"); 
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value=_menuTableService.TGetByID(id);
			_menuTableService.TDelete(value);
			return Ok("Masa Silindi");
		}

		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
            var value = _mapper.Map<MenuTable>(updateMenuTableDto);
            value.MenuTableID = updateMenuTableDto.MenuTableID; // ID'yi manuel eşitle
            _menuTableService.TUpdate(value);
            return Ok("Masa Bilgisi Güncellendi");
		}

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            // UI'ya veriyi UpdateMenuTableDto formatında gönderiyoruz
            return Ok(_mapper.Map<UpdateMenuTableDto>(value));
        }
    }
}
