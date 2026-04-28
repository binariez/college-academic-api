using College.Api.DTOs.Course;
using College.Api.Models;

namespace College.Api.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseResponseDto> CreateAsync(int majorId, CourseRequestDto requestDto);

        Task<Course?> DeleteAsync(int id);

        Task<IEnumerable<CourseResponseDto>> GetAllAsync();

        Task<CourseResponseDto?> GetByIdAsync(int id);

        Task<CourseResponseDto?> UpdateAsync(int id, CourseRequestDto requestDto);
    }
}
