using Flora.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Flora.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7048/api/Product/GetTop4DrinkProducts");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
    }
}
