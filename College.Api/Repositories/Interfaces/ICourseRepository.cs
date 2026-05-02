using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<bool> Exists(int id);

        Task<Course> CreateAsync(Course course);

        Task<Course?> DeleteAsync(int id);

        Task<List<Course>> GetAllAsync();

        Task<Course?> GetByIdAsync(int id);

        Task<Course?> UpdateAsync(Course course);
    }
}
