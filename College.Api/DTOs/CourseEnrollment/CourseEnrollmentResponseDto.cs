using College.Api.Shared.Enums;

namespace College.Api.DTOs.CourseEnrollment
{
    public record CourseEnrollmentResponseDto
    (
        int Id,
        int StudentId,
        string StudentFullName,
        int CourseClassId,
        string CourseName,
        string CourseClassName,
        DateTime EnrolledAt,
        EnrollmentStatus EnrollmentStatus
    );
}
