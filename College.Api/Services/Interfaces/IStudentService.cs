using College.Api.DTOs.Student;
using College.Api.Models;
using College.Api.Repositories;

namespace College.Api.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponseDto> CreateAsync(int majorId, StudentRequestDto requestDto);

        Task<Student?> DeleteAsync(int id);

        Task<IEnumerable<StudentResponseDto>> GetAllAsync();

        Task<StudentResponseDto?> GetByIdAsync(int id);

        Task<StudentResponseDto?> UpdateAsync(int id, StudentRequestDto requestDto);
    }
}
