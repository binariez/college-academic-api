using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface ICourseClassRepository
    {
        Task<bool> Exists(int id);

        Task<CourseClass> CreateAsync(CourseClass courseClass);

        Task DeleteAsync(CourseClass courseClass);

        Task<IEnumerable<CourseClass>> GetAllAsync();

        Task<CourseClass?> GetByIdAsync(int id);

        Task SaveChangesAsync();
    }
}
