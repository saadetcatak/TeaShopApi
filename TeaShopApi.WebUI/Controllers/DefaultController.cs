using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.SubscribeDtos;

namespace TeaShopApi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDTO)
        {


            var client = _httpClientFactory.CreateClient();
            createSubscribeDTO.SubscribeStatus = false;
            var jsonData = JsonConvert.SerializeObject(createSubscribeDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7181/api/Subscribe", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult _WhyChoosePartial()
        {
            return PartialView();
        }

        public PartialViewResult _OurTeaShopPartial()
        {
            return PartialView();
        }
    }
}
