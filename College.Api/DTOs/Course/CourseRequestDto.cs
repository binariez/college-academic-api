using System.ComponentModel.DataAnnotations;

namespace College.Api.DTOs.Course
{
    public record CourseRequestDto
    (
        [Required(ErrorMessage = "Course code required.")]
        [RegularExpression(@"^[A-Z]{3,4}-[0-9]{3,4}$", ErrorMessage = "Invalid code format. Example: TIK-123 or BIND-1234")]
        string Code,

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Course name must between 3-100 characters.")]
        string Name,

        [Range(1, 4, ErrorMessage = "SKS must between 1-4.")]
        int SKS,

        [Range(1, 8, ErrorMessage = "Minimum semester must between 1-8.")]
        int MinimumSemester,

        [Range(1, int.MaxValue, ErrorMessage = "Major ID value must be whole number greater than 0.")]
        int MajorId,

        [Range(1, int.MaxValue, ErrorMessage = "Prerequisite course ID value must be whole number greater than 0.")]
        int? PrerequisiteCourseId
    );
}
