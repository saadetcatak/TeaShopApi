using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.DtoLayer.ContactDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDefaultController : ControllerBase
    {
        private readonly IContactDefaultService _contactDefaultService;

        public ContactDefaultController(IContactDefaultService contactDefaultService)
        {
            _contactDefaultService = contactDefaultService;
        }

        [HttpGet]
        public IActionResult ContactDefaultList()
        {
            var values = _contactDefaultService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContactDefault(CreateContactDefaultDto createContactDefaultDto)
        {
            ContactDefault contactDefault = new ContactDefault()
            {
                Name = createContactDefaultDto.Name,
                Email = createContactDefaultDto.Email,
                Subject = createContactDefaultDto.Subject,
                Message = createContactDefaultDto.Message,
            };
            _contactDefaultService.TInsert(contactDefault);
            return Ok(contactDefault);
        }

        [HttpDelete]
        public IActionResult DeleteContactDefault(int id) 
        {
            var values=_contactDefaultService.TGetById(id);
            _contactDefaultService.TDelete(values);
            return Ok("Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContactDefault(int id)
        {
            var values = _contactDefaultService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateContactDefault(UpdateContactDefaultDto updateContactDefaultDto)
        {
            ContactDefault contactDefault = new ContactDefault()
            {
                Name = updateContactDefaultDto.Name,
                Email = updateContactDefaultDto.Email,
                Subject = updateContactDefaultDto.Subject,
                Message = updateContactDefaultDto.Message,
                ContactDefaultID = updateContactDefaultDto.ContactDefaultID,
            };
            _contactDefaultService.TUpdate(contactDefault);
            return Ok("Güncelleme yapıldı.");
        }
    }
}
