using Flora.WebUI.Dtos.AboutDto;
using Flora.WebUI.Dtos.BasketDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Flora.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {

            HttpContext.Session.SetInt32("TableId", id);
            if (id == null || id == 0)
            {
                TempData["Error"] = "Masa ID alınamadı. Lütfen önce masa seçin.";
                return RedirectToAction("CustomerTableList", "CustomerTable");
            }

            //int tableId = (int)TempData["id"];
            //TempData.Keep("id");

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7048/api/Basket/BasketListByMenuTableWithProductName?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }

            return View(new List<ResultBasketDto>());
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            HttpContext.Session.SetInt32("TableId", id);


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7048/api/Basket?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> SendOrder(int tableId)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsync($"https://localhost:7048/api/Basket/CompleteOrder?tableId={tableId}", null);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                ViewBag.Error = error;
                return View("SendOrder");
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<CompleteOrderResult>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View("SendOrder", result);
        }
    }
}

