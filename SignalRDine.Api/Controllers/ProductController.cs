using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDine.BusinessLayer.Abstract;
using SignalRDine.DtoLayer.ProductDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm ürünleri listeler.
        /// </summary>
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetListAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }

        /// <summary>
        /// Yeni bir ürün oluşturur.
        /// </summary>
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);
            return Ok("Ürün Başarıyla Eklendi");
        }

        /// <summary>
        /// ID değerine göre ürünü siler.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Başarıyla Silindi");
        }

        /// <summary>
        /// ID değerine göre ürün bilgilerini getirir.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }

        /// <summary>
        /// Ürün bilgilerini günceller.
        /// </summary>
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Ürün Başarıyla Güncellendi");
        }

        /// <summary>
        /// Ürünleri bağlı oldukları kategori bilgileriyle birlikte listeler.
        /// </summary>
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _productService.TGetProductsWithCategories();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
        }

        /// <summary>
        /// Toplam ürün sayısını döner.
        /// </summary>
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

        /// <summary>
        /// İçecek kategorisindeki ürün sayısını döner.
        /// </summary>
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }

        /// <summary>
        /// Hamburger kategorisindeki ürün sayısını döner.
        /// </summary>
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }

        /// <summary>
        /// Tüm ürünlerin ortalama fiyatını döner.
        /// </summary>
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }

        /// <summary>
        /// En ucuz ürünün adını döner.
        /// </summary>
        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_productService.TProductNameByMinPrice());
        }

        /// <summary>
        /// En pahalı ürünün adını döner.
        /// </summary>
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }

        /// <summary>
        /// Hamburger kategorisindeki ürünlerin ortalama fiyatını döner.
        /// </summary>
        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            return Ok(_productService.TProductAvgPriceByHamburger());
        }

        /// <summary>
        /// Steak Burger ürününün fiyatını döner.
        /// </summary>
        [HttpGet("ProductPriceBySteakBurger")]
        public IActionResult ProductPriceBySteakBurger()
        {
            return Ok(_productService.TProductPriceBySteakBurger());
        }

        /// <summary>
        /// İçecek kategorisindeki ürünlerin toplam fiyatını döner.
        /// </summary>
        [HttpGet("TotalPriceByDrinkCategory")]
        public IActionResult TotalPriceByDrinkCategory()
        {
            return Ok(_productService.TTotalPriceByDrinkCategory());
        }

        /// <summary>
        /// Salata kategorisindeki ürünlerin toplam fiyatını döner.
        /// </summary>
        [HttpGet("TotalPriceBySaladCategory")]
        public IActionResult TotalPriceBySaladCategory()
        {
            return Ok(_productService.TTotalPriceBySaladCategory());
        }

        /// <summary>
        /// Eklenen son 9 ürünü listeler (Ön yüz vitrini için).
        /// </summary>
        [HttpGet("GetLast9Products")]
        public IActionResult GetLast9Products()
        {
            var value = _productService.TGetLast9Products();
            return Ok(value);
        }

        /// <summary>
        /// Tüm ürünlerin stoktaki/listedeki toplam değerini döner.
        /// </summary>
        [HttpGet("TotalProductPrice")]
        public IActionResult TotalProductPrice()
        {
            var value = _productService.TTotalProductPrice();
            return Ok(value);
        }

        /// <summary>
        /// Ürün çeşidi sayısını döner.
        /// </summary>
        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var value = _productService.TGetProductCount();
            return Ok(value);
        }
    }
}