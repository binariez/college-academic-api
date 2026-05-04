using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface IMajorRepository
    {
        Task<bool> Exists(int id);

        Task<Major> CreateAsync(Major major);

        Task DeleteAsync(Major major);

        Task<IEnumerable<Major>> GetAllAsync();

        Task<Major?> GetByIdAsync(int id);

        Task SaveChangesAsync();
    }
}
