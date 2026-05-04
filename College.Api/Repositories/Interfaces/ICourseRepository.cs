using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<bool> Exists(int id);

        Task<Course> CreateAsync(Course course);

        Task DeleteAsync(Course course);

        Task<IEnumerable<Course>> GetAllAsync();

        Task<Course?> GetByIdAsync(int id);

        Task SaveChangesAsync();
    }
}
