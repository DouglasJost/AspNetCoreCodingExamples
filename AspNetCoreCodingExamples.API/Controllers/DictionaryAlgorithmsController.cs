using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.DTOs;

namespace AspNetCoreCodingExamples.API.Controllers
{
    [ApiController]
    [Route("api/dictionary")]
    public class DictionaryAlgorithmsController : ControllerBase
    {
        private readonly IDictionaryAlgorithms _dictionaryAlgorithms;

        public DictionaryAlgorithmsController(IDictionaryAlgorithms dictionaryAlgorithms)
        {
            _dictionaryAlgorithms = dictionaryAlgorithms;
        }

        [Route("try-get-value")]
        [HttpPost]
        public ActionResult<int> TryGetValue([FromBody] TryGetValueRequestDto request)
        {
            var dictionary = new Dictionary<string, int> { { "one", 1 }, { "two", 2 }, { "three", 3 } };
            if (_dictionaryAlgorithms.TryGetValue(dictionary, request.Key, out int value))
            {
                return Ok(value);
            }
            return NotFound();
        }

        [Route("merge-dictionaries")]
        [HttpPost]
        public ActionResult<Dictionary<string, int>> MergeDictionaries([FromBody] MergeRequestDto request)
        {
            var result = _dictionaryAlgorithms.MergeDictionaries(request.First, request.Second);
            return Ok(result);
        }

        [Route("count-keys-starting-with-prefix")]
        [HttpPost]
        public ActionResult<int> CountKeysStartingWith([FromBody] CountKeysStartingWithPrefixRequestDto request)
        {
            var dictionary = new Dictionary<string, int>
            {
                { "apple", 1 }, { "banana", 2 }, { "apricot", 3 }, { "cherry", 4 }
            };
            var count = _dictionaryAlgorithms.CountKeysStartingWith(dictionary, request.Prefix);
            return Ok(count);
        }

        [Route("keys-for-value")]
        [HttpPost]
        public ActionResult<List<string>> GetKeysForValue([FromBody] GetKeysForValueRequestDto request)
        {
            var dictionary = new Dictionary<string, int>
            {
                { "alpha", 10 }, { "beta", 20 }, { "gamma", 10 }
            };
            var keys = _dictionaryAlgorithms.GetKeysForValue(dictionary, request.Value);
            return Ok(keys);
        }

        [Route("invert")]
        [HttpPost]
        public ActionResult<Dictionary<string, int>> Invert([FromBody] InvertRequestDto request)
        {
            try
            {
                var inverted = _dictionaryAlgorithms.Invert(request.Input);
                return Ok(inverted);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
