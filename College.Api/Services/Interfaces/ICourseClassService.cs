using College.Api.DTOs.CourseClass;

namespace College.Api.Services.Interfaces
{
    public interface ICourseClassService
    {
        Task<CourseClassResponseDto> CreateAsync(int courseId, CourseClassRequestDto requestDto);

        Task<CourseClassResponseDto?> DeleteAsync(int id);

        Task<IEnumerable<CourseClassResponseDto>> GetAllAsync();

        Task<CourseClassResponseDto?> GetByIdAsync(int id);

        Task<CourseClassResponseDto?> UpdateAsync(int id, CourseClassRequestDto requestDto);
    }
}
