using College.Api.DTOs.Major;

namespace College.Api.Services.Interfaces
{
    public interface IMajorService
    {
        Task<MajorResponseDto> CreateAsync(MajorRequestDto requestDto);

        Task DeleteAsync(int id);

        Task<IEnumerable<MajorResponseDto>> GetAllAsync();

        Task<MajorResponseWithStudentDto?> GetByIdAsync(int id);

        Task<MajorResponseDto?> UpdateAsync(int id, MajorRequestDto requestDto);
    }
}
