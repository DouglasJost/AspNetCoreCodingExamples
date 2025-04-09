using System.Collections.Generic;

namespace AspNetCoreCodingExamples.Domain.DataStructures.DTOs
{
    public class MergeRequestDto
    {
        public Dictionary<string, int> First { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> Second { get; set; } = new Dictionary<string, int>();
    }
}
