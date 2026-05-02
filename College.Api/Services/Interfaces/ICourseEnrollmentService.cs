using College.Api.DTOs.CourseEnrollment;

namespace College.Api.Services.Interfaces
{
    public interface ICourseEnrollmentService
    {
        Task<CourseEnrollmentResponseDto> CreateAsync(CourseEnrollmentRequestDto requestDto);

        Task<IEnumerable<CourseEnrollmentResponseDto>> GetAllAsync();

        Task<CourseEnrollmentResponseDto?> DeleteAsync(int courseEnrollmentId);

        Task<CourseEnrollmentResponseDto?> DropEnrollmentAsync(int courseEnrollmentId);

        Task<CourseEnrollmentResponseDto?> CompleteEnrollmentAsync(int courseEnrollmentId);

        Task<CourseEnrollmentResponseDto?> ReEnrollAsync(int courseEnrollmentId);

        Task<CourseEnrollmentResponseDto?> GetByIdAsync(int id);

        Task<IEnumerable<CourseEnrollmentResponseDto>> GetByStudentIdAsync(int studentId);
    }
}