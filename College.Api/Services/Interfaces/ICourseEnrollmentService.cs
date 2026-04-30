using College.Api.DTOs.CourseEnrollment;

namespace College.Api.Services.Interfaces
{
    public interface ICourseEnrollmentService
    {
        Task<CourseEnrollmentResponseDto> CreateAsync(CourseEnrollmentRequestDto requestDto);

        Task<CourseEnrollmentResponseDto?> DeleteAsync(int courseEnrollmentId);

        Task<CourseEnrollmentResponseDto?> GetByIdAsync(int id);

        Task<IEnumerable<CourseEnrollmentResponseDto>> GetByStudentIdAsync(int studentId);
    }
}