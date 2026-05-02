using College.Api.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace College.Api.DTOs.Student
{
    public record StudentRequestDto
    (
        [MinLength(3, ErrorMessage = "Must be at least 3 characters.")]
        [MaxLength(100, ErrorMessage = "Must be at most 100 characters.")]
        string FullName,

        [DataType(DataType.Date)]
        [Range(typeof(DateOnly), "1/1/1970", "31/12/2015", ErrorMessage = "Date must between 1970-2015.")]
        DateOnly DateOfBirth,

        [Required(ErrorMessage = "Gender required.")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender.")]
        Gender Gender,

        [MinLength(3, ErrorMessage = "Must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "Must be at most 20 characters.")]
        string Religion,

        [MinLength(5, ErrorMessage = "Must be at least 5 characters.")]
        [MaxLength(250, ErrorMessage = "Must be at most 250 characters.")]
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
