using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface ICourseClassRepository
    {
        Task<bool> Exists(int id);

        Task<CourseClass> CreateAsync(CourseClass courseClass);

        Task<CourseClass?> DeleteAsync(int id);

        Task<List<CourseClass>> GetAllAsync();

        Task<CourseClass?> GetByIdAsync(int id);

        Task<CourseClass?> UpdateAsync(CourseClass courseClass);
    }
}
