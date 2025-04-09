using Microsoft.AspNetCore.Mvc;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.DTOs;

namespace AspNetCoreCodingExamples.API.Controllers
{
    [ApiController]
    [Route("api/stack-queue")]
    public class StackQueueExamplesController : ControllerBase
    {
        private readonly IStackQueueExamples _stackQueueExamples;

        public StackQueueExamplesController(IStackQueueExamples stackQueueExamples)
        {
            _stackQueueExamples = stackQueueExamples;
        }

        [Route("are-brackets-balanced")]
        [HttpPost]
        public IActionResult AreBracketsBalanced([FromBody] AreBracketsBalancedRequestDto request)
        {
            return Ok(_stackQueueExamples.AreBracketsBalanced(request.TestStr));
        }

        [Route("reverse-queue")]
        [HttpPost]
        public IActionResult ReverseQueue([FromBody] ReverseQueueRequestDto request)
        {
            if (request == null || request.InputQueue == null)
            {
                return BadRequest("Queue cannot be null.");
            }

            var reversed = _stackQueueExamples.ReverseQueue(request.InputQueue);
            return Ok(reversed);
        }
    }
}
