﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.T1 = "Dashboard";
            ViewBag.T2 = "Dashboard";
            var client = _httpClientFactory.CreateClient();

            var responseMessage1 = await client.GetAsync("https://localhost:7181/api/Statistics/GetDrinkAveragePrice");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.v1 = jsonData1;


            var responseMessage2 = await client.GetAsync("https://localhost:7181/api/Statistics/GetDrinkCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.v2 = jsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:7181/api/Statistics/GetLastDrinkName");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = jsonData3;

            var responseMessage4 = await client.GetAsync("https://localhost:7181/api/Statistics/GetMaxPriceDrink");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.v4= jsonData4;

            var responseMessage5 = await client.GetAsync("https://localhost:7181/api/Statistics/GetTotatlContact");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.v5 = jsonData5;

            var responseMessage6 = await client.GetAsync("https://localhost:7181/api/Statistics/GetTotalTestimonial");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.v6 = jsonData6;

            return View();
        }

       
    }
}
