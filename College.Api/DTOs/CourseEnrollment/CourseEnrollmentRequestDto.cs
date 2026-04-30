namespace College.Api.DTOs.CourseEnrollment
{
    public record CourseEnrollmentRequestDto
    (
        int StudentId,
        int CourseClassId
    );
}
