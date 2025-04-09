using System.Collections.Generic;

namespace AspNetCoreCodingExamples.Domain.DataStructures.DTOs
{
    public class InvertRequestDto
    {
        public Dictionary<int, string> Input { get; set; } = new Dictionary<int, string>();
    }
}
