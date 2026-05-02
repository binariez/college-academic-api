using System.ComponentModel.DataAnnotations;

namespace College.Api.DTOs.CourseEnrollment
{
    public record CourseEnrollmentRequestDto
    (
        [Range(1, int.MaxValue, ErrorMessage = "Student ID must be whole number greater than 0.")]
        int StudentId,

        [Range(1, int.MaxValue, ErrorMessage = "Course class ID must be whole number greater than 0.")]
        int CourseClassId
    );
}
