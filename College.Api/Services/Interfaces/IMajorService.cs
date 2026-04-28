using College.Api.DTOs.Major;
using College.Api.Models;

namespace College.Api.Services.Interfaces
{
    public interface IMajorService
    {
        Task<MajorResponseDto> CreateAsync(MajorRequestDto requestDto);

        Task<Major?> DeleteAsync(int id);

        Task<IEnumerable<MajorResponseDto>> GetAllAsync();

        Task<MajorResponseWithStudentDto?> GetByIdAsync(int id);

        Task<MajorResponseDto?> UpdateAsync(int id, MajorRequestDto requestDto);
    }
}
