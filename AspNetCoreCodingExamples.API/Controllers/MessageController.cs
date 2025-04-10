using AspNetCoreCodingExamples.Domain.MessageSelector.DTOs;
using AspNetCoreCodingExamples.Domain.MessageSelector.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCodingExamples.API.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageServiceFactory _factory;

        public MessageController(IMessageServiceFactory factory)
        {
            _factory = factory;
        }

        [Route("send")]
        [HttpPost]
        public IActionResult SendMessage([FromBody] MessageRequestDto request)
        {
            var service = _factory.GetService(request.Type);
            var result = service.SendMessage(request.Message);
            return Ok(result);
        }
    }
}
