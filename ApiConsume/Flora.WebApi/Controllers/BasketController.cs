using Flora.BusinessLayer.Abstract;
using Flora.DataAccessLayer.Concrete;
using Flora.DtoLayer.BasketDto;
using Flora.EntityLayer.Entities;
using Flora.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new Context();
            var values = context.Baskets?.Include(x => x.Product).Where(y => y.MenuTableId == id)
                .Select(z => new ResultBasketListWithProducts
                {
                    BasketId = z.BasketId,
                    Count = (int)(z.Count),
                    MenuTableId = z.MenuTableId,
                    Price = z.Price,
                    ProductId = z.ProductId,
                    TotalPrice = z.TotalPrice,
                    ProductName =z.Product!.ProductName,
                    ImageUrl = z.Product.ImageUrl
                }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new Context();

            var existingBasket = context.Baskets
                .FirstOrDefault(x => x.ProductId == createBasketDto.ProductId && x.MenuTableId == createBasketDto.MenuTableId);

            var productPrice = context.Products
                .Where(x => x.ProductId == createBasketDto.ProductId)
                .Select(y => y.Price)
                .FirstOrDefault();

            if (existingBasket != null)
            {
                existingBasket.Count += 1;
                existingBasket.TotalPrice = existingBasket.Count * productPrice;
                context.Baskets.Update(existingBasket);
            }
            else
            {
                var newBasket = new Basket()
                {
                    Count = 1,
                    MenuTableId = createBasketDto.MenuTableId,
                    Price = productPrice,
                    ProductId = createBasketDto.ProductId,
                    TotalPrice = productPrice * 1
                };
                context.Baskets.Add(newBasket);
            }

            context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok();
        }
        [HttpPost("UpdateCount")]
        public IActionResult UpdateCount( int basketId, int newCount)
        {
            using var context = new Context();
            var basketItem = context.Baskets.Find(basketId);
            if (basketItem == null)
                return NotFound();

            if (newCount < 1)
                return BadRequest("Adet 1’den küçük olamaz.");

            basketItem.Count = newCount;
            basketItem.TotalPrice = basketItem.Price * newCount;

            context.SaveChanges();

            return Ok(new { success = true, newCount = basketItem.Count, totalPrice = basketItem.TotalPrice });
        }
    }
}
