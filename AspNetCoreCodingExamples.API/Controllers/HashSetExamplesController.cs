using Microsoft.AspNetCore.Mvc;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.DTOs;

namespace AspNetCoreCodingExamples.API.Controllers
{
    [ApiController]
    [Route("api/hash-set")]
    public class HashSetExamplesController : ControllerBase
    {
        private readonly IHashSetExamples _hashSetExamples;

        public HashSetExamplesController(IHashSetExamples hashSetExamples)
        {
            _hashSetExamples = hashSetExamples;
        }

        [Route("has-duplicates")]
        [HttpPost]
        public IActionResult HasDuplicates([FromBody] HasDuplicatesRequestDto request)
        {
            var hasDuplicates = _hashSetExamples.HasDuplicates(request.Values);
            return Ok(hasDuplicates);
        }

        [Route("get-set-difference")]
        [HttpPost]
        public IActionResult GetSetDifference([FromBody] GetSetDifferenceRequestDto request)
        {
            var setDifferences = _hashSetExamples.GetSetDifference(request.FirstHashSet, request.SecondHashSet);
            return Ok(setDifferences);
        }

        [Route("get-intersection")]
        [HttpPost]
        public IActionResult GetIntersection([FromBody] GetIntersectionRequestDto request)
        {
            var setIntersection = _hashSetExamples.GetIntersection(request.FirstHashSet, request.SecondHashSet);
            return Ok(setIntersection);
        }
    }
}
