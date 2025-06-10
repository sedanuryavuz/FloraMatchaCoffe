using AutoMapper;
using Flora.BusinessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DtoLayer.DiscountDto;
using Flora.DtoLayer.ProductDto;
using Flora.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flora.WebApi.Controllers
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
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetAll();
            return Ok(values);
        }
        [HttpGet("GetProductsWithCategories")]
        public IActionResult GetProductsWithCategories()
        {
            var context = new Context();
            var values = context.Products!
                .Include(x => x.Category).Select(y => new ResultProductWithCategory
                {
                    Description = y.Description,
                    ImageUrl = y.ImageUrl,
                    Price = y.Price,
                    ProductId = y.ProductId,
                    ProductName = y.ProductName,
                    ProductStatus = y.ProductStatus,
                    CategoryName = y.Category!.CategoryName
                })
                .ToList();
            return Ok(values.ToList());
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var value = _productService.TProductCount();
            return Ok(value);
        }
        [HttpGet("ProductCountByCategoryDessert")]
        public IActionResult ProductCountByCategoryDessert()
        {
            var value = _productService.TProductCountByCategoryDessert();
            return Ok(value);
        }
        [HttpGet("ProductCountByCategoryDrink")]
        public IActionResult ProductCountByCategoryDrink()
        {
            var value = _productService.TProductCountByCategoryDrink();
            return Ok(value);
        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            var value = _productService.TProductPriceAvg();
            return Ok(value);
        }
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            var value = _productService.TProductNameByMaxPrice();
            return Ok(value);
        }
        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            var value = _productService.TProductNameByMinPrice();
            return Ok(value);
        }
        [HttpGet("ProductPriceByCategoryDrink")]
        public IActionResult ProductPriceByCategoryDrink()
        {
            var value = _productService.TProductPriceByCategoryDrink();
            return Ok(value);
        }
        [HttpGet("GetTop4DrinkProducts")]
        public IActionResult GetTop5DrinkProducts()
        {
            var values = _productService.TGetTop4DrinkProducts();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var entity = _mapper.Map<Product>(createProductDto);
            _productService.TInsert(entity);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            if (value == null)
            {
                return NotFound("Silinecek veri bulunamadı.");
            }
            _productService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var entity = _productService.TGetById(updateProductDto.ProductId);
            if (entity == null)
            {
                return NotFound("Güncellenecek veri bulunamadı.");
            }
            _mapper.Map(updateProductDto, entity);
            _productService.TUpdate(entity);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            if (value == null)
            {
                return NotFound("Ürün bulunamadı.");
            }
            return Ok(value);
        }
    }
}
