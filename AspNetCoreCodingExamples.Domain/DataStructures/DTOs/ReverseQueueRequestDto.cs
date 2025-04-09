using System.Collections.Generic;

namespace AspNetCoreCodingExamples.Domain.DataStructures.DTOs
{
    public class ReverseQueueRequestDto
    {
        public Queue<string> InputQueue { get; set; } = new Queue<string>();
    }
}
