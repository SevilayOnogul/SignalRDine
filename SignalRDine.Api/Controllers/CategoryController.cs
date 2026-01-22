using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.CategoryDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList() {
        
            var values=_mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            value.CategoryStatus = true; 
            _categoryService.TAdd(value);
            return Ok("Kategori Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) 
        { 
            var value=_categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value=_mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(_mapper.Map<GetCategoryDto>(value)); 
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
          
            return Ok(_categoryService.TCategoryCount());
        } 
        
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
          
            return Ok(_categoryService.TActiveCategoryCount());
        }

		[HttpGet("PassiveCategoryCount")]
		public IActionResult PassiveCategoryCount()
		{

			return Ok(_categoryService.TPassiveCategoryCount());
		}

	}
}
