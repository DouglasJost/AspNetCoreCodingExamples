using System.Collections.Generic;

namespace AspNetCoreCodingExamples.Domain.DataStructures.DTOs
{
    public class GetIntersectionRequestDto
    {
        public IEnumerable<string> FirstHashSet { get; set; } = new List<string>();
        public IEnumerable<string> SecondHashSet { get; set; } = new List<string>();
    }
}
