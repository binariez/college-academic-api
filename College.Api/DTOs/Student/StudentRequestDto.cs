using College.Api.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace College.Api.DTOs.Student
{
    public record StudentRequestDto
    (
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must between 3-100 characters.")]
        string FullName,

        [DataType(DataType.Date)]
        [Range(typeof(DateOnly), "1970-01-01", "2015-12-31", ErrorMessage = "Date must between 1970-2015.")]
        DateOnly DateOfBirth,

        [Required(ErrorMessage = "Gender required.")]
        Gender Gender,

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Religion must between 3-20 characters.")]
        string Religion,

        [StringLength(250, MinimumLength = 5, ErrorMessage = "Address must between 5-250 characters.")]
        string Address,

        [Required]
        [RegularExpression(@"^[0-9]{10,13}$", ErrorMessage = "Invalid phone number format. Must between 10-13 digits.")]
        string PhoneNumber,

        [Required]
        [RegularExpression(@"^[0-9]{10,13}$", ErrorMessage = "Invalid phone number format. Must between 10-13 digits.")]
        string EmergencyContactPhone,

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        string Email,

        [Range(1, int.MaxValue, ErrorMessage = "ID value must be whole number greater than 0.")]
        int MajorId
    );
}
