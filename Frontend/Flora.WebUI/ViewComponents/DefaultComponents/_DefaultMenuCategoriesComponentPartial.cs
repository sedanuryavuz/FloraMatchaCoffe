using Flora.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Flora.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultMenuCategoriesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultMenuCategoriesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7048/api/Category");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }
    }
}