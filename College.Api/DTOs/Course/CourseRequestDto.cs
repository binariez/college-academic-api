namespace College.Api.DTOs.Course
{
    public record CourseRequestDto
    (
        string Code,
        string Name,
        int SKS,
        int MinimumSemester
        int MajorId
    );
}
