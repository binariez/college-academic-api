using College.Api.DTOs.Major;
using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface IMajorRepository
    {
        Task<bool> MajorExists(int id);

        Task<Major> CreateAsync(Major major);

        Task<Major?> DeleteAsync(int id);

        Task<List<Major>> GetAllAsync();

        Task<Major?> GetByIdAsync(int id);

        Task<Major?> UpdateAsync(Major major);
    }
}
