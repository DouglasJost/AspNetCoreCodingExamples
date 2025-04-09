namespace AspNetCoreCodingExamples.Domain.DataStructures.DTOs
{
    public class ReplaceVowelsWithSymbolRequestDto
    {
        public string Input { get; set; } = string.Empty;
        public char Symbol { get; set; } = default;
    }
}
