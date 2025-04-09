using System.ComponentModel.DataAnnotations;

namespace AspNetCoreCodingExamples.Domain.DataStructures.DTOs
{
    public class IpAddressValidationRequestDto
    {
        [Required(ErrorMessage = "IpAddress attribute is required.")]
        public string? IpAddress { get; set; }
    }
}
