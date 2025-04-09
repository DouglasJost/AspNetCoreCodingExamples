using Microsoft.AspNetCore.Mvc;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.DTOs;

namespace AspNetCoreCodingExamples.API.Controllers
{
    [ApiController]
    [Route("api/char")]
    public class CharStringAlgorithmsController : ControllerBase
    {
        private readonly ICharStringAlgorithms _charAlgorithms;

        public CharStringAlgorithmsController(ICharStringAlgorithms charAlgorithms)
        {
            _charAlgorithms = charAlgorithms;
        }

        [Route("format-alphabet-alternating-case")]
        [HttpPost]
        public IActionResult FormatAlphabetAlternatingCase([FromBody] FormatAlphabetAlternatingCaseRequestDto request)
        {
            return Ok(_charAlgorithms.FormatAlphabetAlternatingCase(request.IsFirstCharUpper));
        }

        [Route("convert-from-12To24-hours-format")]
        [HttpPost]
        public IActionResult ConvertFrom12To24HoursFormat([FromBody] ConvertFrom12To24HoursFormatRequestDto request)
        {
            return Ok(_charAlgorithms.ConvertFrom12To24HoursFormat(request.InputTime));
        }

        [Route("is-palindrome")]
        [HttpPost]
        public IActionResult IsPalindrome([FromBody] IsPalindromeRequestDto request)
        {
            return Ok(_charAlgorithms.IsPalindrome(request.Input));
        }

        [Route("replace-vowels-with-symbol")]
        [HttpPost]
        public IActionResult ReplaceVowelsWithSymbol([FromBody] ReplaceVowelsWithSymbolRequestDto request)
        {
            return Ok(_charAlgorithms.ReplaceVowelsWithSymbol(request.Input, request.Symbol));
        }

        [Route("is-valid-ip-address")]
        [HttpPost]
        public IActionResult IsValidIpAddress([FromBody] IpAddressValidationRequestDto request)
        {
            return Ok(_charAlgorithms.IsValidIpAddress(request.IpAddress));
        }

        [Route("remove-special-characters")]
        [HttpPost]
        public IActionResult RemoveSpecialCharacters([FromBody] RemoveSpecialCharactersRequestDto request)
        {
            var result = _charAlgorithms.RemoveSpecialCharacters(request.Sentence!);

            var response = new RemoveSpecialCharactersResponseDto()
            {
                OriginalSentence = request.Sentence!,
                SentenceWithoutSpecialCharacters = result.sentenceWithoutSpecialChars!,
                RemovedSpecialCharacters = result.specialChars!
            };

            return Ok(response);
        }
    }
}
