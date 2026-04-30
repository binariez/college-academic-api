using College.Api.DTOs.Student;

namespace College.Api.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponseDto> CreateAsync(int majorId, StudentRequestDto requestDto);

        Task<StudentResponseDto?> DeleteAsync(int id);

        Task<IEnumerable<StudentResponseDto>> GetAllAsync();

        Task<StudentResponseDto?> GetByIdAsync(int id);

        Task<StudentResponseDto?> UpdateAsync(int id, StudentRequestDto requestDto);
    }
}
