﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DrinkController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DrinkController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7181/api/Drinks");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<List<ResultDrinkDto>>(jsonData);
				return View(values);
			}
			return View();
		}


		[HttpGet]
		public IActionResult CreateDrink()
		{
			return View();
		}


        [HttpPost]
        public async Task<IActionResult> CreateDrink(CreateDrinkDto createDrinkDto)
        {
			var client=_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(createDrinkDto);
			StringContent content= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage=await client.PostAsync("https://localhost:7181/api/Drinks",content);
            if (responseMessage.IsSuccessStatusCode)
            {

				return RedirectToAction("Index");
            }
            return View();
        }
    }
}
