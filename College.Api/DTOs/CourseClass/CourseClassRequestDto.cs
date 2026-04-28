using College.Api.Shared.Enums;

namespace College.Api.DTOs.CourseClass
{
    public record CourseClassRequestDto
    (
        string Name,
        int CourseId,
        int AcademicYear,
        SemesterType SemesterType
    );
}
