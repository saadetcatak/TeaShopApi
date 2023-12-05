using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.MessageDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
           var values= _messageService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDtos createMessageDtos)
        {
            Message message = new Message()
            {
                MessageDetail=createMessageDtos.MessageDetail,
                MessageSenderName=createMessageDtos.MessageSenderName,
                MessageSubject=createMessageDtos.MessageSubject,
                MessageEmail=createMessageDtos.MessageEmail,
                MessageSendDate=createMessageDtos.MessageSendDate,
            };
            _messageService.TInsert(message);
            return Ok("Mesaj başarılı bir şekilde eklendi.");

        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id) 
        { 
            var values=_messageService.TGetById(id);
            _messageService.TDelete(values);
            return Ok("Mesaj başarılı bir şekilde silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id) 
        {
            var values = _messageService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDtos updateMessageDtos)
        {
            Message message = new Message()
            {
                MessageID = updateMessageDtos.MessageID,
                MessageDetail = updateMessageDtos.MessageDetail,
                MessageEmail = updateMessageDtos.MessageEmail,
                MessageSendDate = updateMessageDtos.MessageSendDate,
                MessageSenderName = updateMessageDtos.MessageSenderName,
                MessageSubject = updateMessageDtos.MessageSubject,
            };
            _messageService.TUpdate(message);
            return Ok("Mesaj başarılı bir şekilde güncellendi.");
        }
    }
}
