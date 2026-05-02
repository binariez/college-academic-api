using College.Api.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace College.Api.DTOs.CourseClass
{
    public record CourseClassRequestDto
    (
        [RegularExpression(@"^[A-Z]{3,4}-[0-9]{3,4}-[A-Z]{1}$", ErrorMessage = "Invalid code format. Example: TIK-123-A, BIND-1234-B")]
        string Name,

        [Range(1, int.MaxValue, ErrorMessage = "Course ID value must be whole number greater than 0.")]
        int CourseId,

        [Range(2020, 2100, ErrorMessage = "Invalid year. Must between 2020-2100.")]
        int AcademicYear,

        [Required(ErrorMessage = "Semester type required.")]
        SemesterType SemesterType
    );
}
