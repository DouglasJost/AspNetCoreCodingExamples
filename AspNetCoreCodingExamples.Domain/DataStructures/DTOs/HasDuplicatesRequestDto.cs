using System.Collections.Generic;

namespace AspNetCoreCodingExamples.Domain.DataStructures.DTOs
{
    public class HasDuplicatesRequestDto
    {
        public List<string> Values { get; set; } = new List<string>();
    }
}
