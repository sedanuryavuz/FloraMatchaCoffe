﻿using Flora.WebUI.Dtos.CategoryDtos;
using Flora.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Flora.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7048/api/Product/GetProductsWithCategories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(products);
            }
            return View();
        }
        [HttpGet]
        public async Task <IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = client.GetAsync("https://localhost:7048/api/Category");
            var jsonData = await responseMessage.Result.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryId.ToString()
                                                    }).ToList();
            ViewBag.v = values2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            createProductDto.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7048/api/Product", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7048/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = client1.GetAsync("https://localhost:7048/api/Category");
            var jsonData1 = await responseMessage1.Result.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
            List<SelectListItem> values2 = (from x in values1
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v = values2;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7048/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
             

                return View(product);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            updateProductDto.ProductStatus = true; 
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7048/api/Product/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}