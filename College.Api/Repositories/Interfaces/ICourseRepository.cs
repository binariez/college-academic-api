using College.Api.DTOs.Course;
using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course?> Exists(int id);

        Task<Course> CreateAsync(Course course);

        Task<Course?> DeleteAsync(int id);

        Task<List<Course>> GetAllAsync();

        Task<Course?> GetByIdAsync(int id);

        Task<Course?> UpdateAsync(Course course);
    }
}
