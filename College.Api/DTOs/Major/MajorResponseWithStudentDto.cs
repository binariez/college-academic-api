using College.Api.DTOs.Student;

namespace College.Api.DTOs.Major
{
    public record MajorResponseWithStudentDto
    (
        int Id,
        string Code,
        string Name,
        ICollection<StudentSimpleDto> Students
    );
}
