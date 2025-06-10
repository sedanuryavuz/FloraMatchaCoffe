using Flora.WebUI.Dtos.AboutDto;
using Flora.WebUI.Dtos.BasketDtos;
using Flora.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Flora.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            HttpContext.Session.SetInt32("TableId", id);
            ViewBag.v = id;
            TempData["id"] = id;
            TempData.Keep("TableId");
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7048/api/Product/GetProductsWithCategories");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id,int menuTableId)
        {
            CreateBasketDto createBasketDto = new CreateBasketDto()
            {
                ProductId = id,
                MenuTableId =menuTableId
            };
            int? tableId = HttpContext.Session.GetInt32("id");
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7048/api/Basket", stringContent);

            var client2 = _httpClientFactory.CreateClient();
            await client2.GetAsync("https://localhost:7048/api/MenuTables/ChangeMenuTableStatusToTrue?id="+menuTableId);


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);
        }
    }
}
