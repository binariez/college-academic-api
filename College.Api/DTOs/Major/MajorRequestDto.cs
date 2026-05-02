using System.ComponentModel.DataAnnotations;

namespace College.Api.DTOs.Major
{
    public record MajorRequestDto
    (
        [Required(ErrorMessage = "Major code required.")]
        [RegularExpression(@"^[A-Z]{5}$", ErrorMessage = "Invalid major code format. Must be 5 capital letters.")]
        string Code,

        [StringLength(50, MinimumLength = 8, ErrorMessage = "Major name must between 8-50 characters.")]
        string Name
    );
}
