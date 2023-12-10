using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.SubscribeDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
      private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            Subscribe subscribe = new Subscribe()
            { 
                Mail = createSubscribeDto.Mail,
                SubscribeStatus = createSubscribeDto.SubscribeStatus,
                

            };
            _subscribeService.TInsert(subscribe);
            return Ok(subscribe);
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _subscribeService.TGetById(id);
            _subscribeService.TDelete(values);
            return Ok("İçecek silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetDrink(int id)
        {
            var values = _subscribeService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(UpdateSubscribeDto updateSubscribeDto)
        {
            Subscribe subscribe = new Subscribe()
            {
                SubscribeID=updateSubscribeDto.SubscribeID,
                Mail =updateSubscribeDto.Mail,
                SubscribeStatus = updateSubscribeDto.SubscribeStatus,

            };
            _subscribeService.TUpdate(subscribe);
            return Ok("Güncelleme yapıldı.");
        }
    }
}
