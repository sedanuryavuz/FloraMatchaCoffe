using Flora.WebUI.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Flora.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutUsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultAboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7048/api/About");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return View(values);
        }
    }
}