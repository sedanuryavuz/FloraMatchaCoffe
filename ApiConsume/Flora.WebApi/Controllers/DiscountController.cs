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
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _discountService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var entity = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TInsert(entity);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            if (value == null)
            {
                return NotFound("Silinecek veri bulunamadı.");
            }
            _discountService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var entity = _discountService.TGetById(updateDiscountDto.DiscountId);
            if (entity == null)
            {
                return NotFound("Güncellenecek veri bulunamadı.");
            }
            _mapper.Map(updateDiscountDto, entity);
            _discountService.TUpdate(entity);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            if (value == null)
            {
                return NotFound("Veri bulunamadı.");
            }
            return Ok(value);
        }
        [HttpGet("GetDiscountedProducts")]
        public IActionResult GetDiscountedProducts()
        {
            var context = new Context();
            var values = context.Discounts!
                .Include(x => x.Product).Select(y => new ProductWithDiscountDto
                {
                    ProductName = y.Product!.ProductName,
                    Description = y.Product.Description,
                    ImageUrl = y.Product.ImageUrl,
                    ProductPrice = y.Product.Price,
                    DiscountedPrice = y.Product.Price - (y.Product.Price * Convert.ToDecimal(y.Amount) / 100),

                })
                .ToList();
            return Ok(values.ToList());
        }
        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            var value = _discountService.TGetById(id);
            if (value == null)
            {
                return NotFound("Veri bulunamadı.");
            }
            value.Status = true;
            _discountService.TUpdate(value);
            return Ok("Durum başarılı bir şekilde güncellendi.");
        }
        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            var value = _discountService.TGetById(id);
            if (value == null)
            {
                return NotFound("Veri bulunamadı.");
            }
            value.Status = false;
            _discountService.TUpdate(value);
            return Ok("Durum başarılı bir şekilde güncellendi.");
        }
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            var values = _discountService.TGetListByStatusTrue();
            return Ok(values);
        }
    }
}