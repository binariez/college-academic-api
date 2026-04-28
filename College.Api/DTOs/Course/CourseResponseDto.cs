namespace College.Api.DTOs.Course
{
    public record CourseResponseDto
    (
        int Id,
        string Code,
        string Name,
        int SKS,
        int MinimumSemester,
        int MajorId
    );
}