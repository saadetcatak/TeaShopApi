using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.ContactDefaultDtos;
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
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {


            using (var client = _httpClientFactory.CreateClient())
            {

                var content = new StringContent(JsonConvert.SerializeObject(createSubscribeDto), Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7181/api/Subscribe", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

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

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDefaultDto createContactDefaultDto)
        {

            using (var client = _httpClientFactory.CreateClient())
            {

                var content = new StringContent(JsonConvert.SerializeObject(createContactDefaultDto), Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7181/api/ContactDefault", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }


            return View();

        }
    }
}
