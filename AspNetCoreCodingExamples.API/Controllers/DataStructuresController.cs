using Microsoft.AspNetCore.Mvc;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;

namespace AspNetCoreCodingExamples.API.Controllers
{
    [ApiController]
    [Route("api/data-structures/arrays")]
    public class DataStructuresController : ControllerBase
    {
        private readonly IArrayAlgorithms _arrayAlgorithms;

        public DataStructuresController(IArrayAlgorithms arrayAlgorithms)
        {
            _arrayAlgorithms = arrayAlgorithms;
        }

        [Route("reverse")]
        [HttpPost]
        public IActionResult Reverse([FromBody] int[] input)
        {
            return Ok(_arrayAlgorithms.Reverse(input));
        }

        [Route("find-min")]
        [HttpPost]
        public IActionResult FindMin([FromBody] int[] input)
        {
            return Ok(_arrayAlgorithms.FindMin(input));
        }

        [Route("find-max")]
        [HttpPost]
        public IActionResult FindMax([FromBody] int[] input)
        {
            return Ok(_arrayAlgorithms.FindMax(input));
        }

        [Route("sum")]
        [HttpPost]
        public IActionResult Sum([FromBody] int[] input)
        {
            return Ok(_arrayAlgorithms.Sum(input));
        }

        [Route("find-duplicates")]
        [HttpPost]
        public IActionResult FindDuplicates([FromBody] int[] input)
        {
            return Ok(_arrayAlgorithms.FindDuplicates(input));
        }
    }
}
