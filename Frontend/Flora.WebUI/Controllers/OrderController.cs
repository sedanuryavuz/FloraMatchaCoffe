using Flora.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

public class OrderController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OrderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

}
