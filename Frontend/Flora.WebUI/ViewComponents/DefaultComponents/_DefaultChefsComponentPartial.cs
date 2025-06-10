using Flora.WebUI.Dtos.EmployeeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Flora.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultChefsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultChefsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7048/api/Employees");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
            return View(values);
        }
    }
}
