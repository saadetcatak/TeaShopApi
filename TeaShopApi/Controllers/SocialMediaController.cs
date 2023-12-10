using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.SocialMediaDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values =_socialMediaService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
               

            };
            _socialMediaService.TInsert(socialMedia);
            return Ok("v başarılı bir şekilde eklendi.");

        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(values);
            return Ok("Sosyal medya başarılı bir şekilde silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
           SocialMedia socialMedia = new SocialMedia()
            {
                


            };
           _socialMediaService.TUpdate(socialMedia);
            return Ok("Sosyal medya başarılı bir şekilde güncellendi.");
        }
    }
}

    