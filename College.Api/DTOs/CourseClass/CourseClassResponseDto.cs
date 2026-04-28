using College.Api.Shared.Enums;

namespace College.Api.DTOs.CourseClass
{
    public record CourseClassResponseDto
    (
        int Id,
        string Name,
        int CourseId,
        int AcademicYear,
        SemesterType SemesterType
    );
}
