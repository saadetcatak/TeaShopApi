using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.ViewComponents.Default
{
    public class _DrinkListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DrinkListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
