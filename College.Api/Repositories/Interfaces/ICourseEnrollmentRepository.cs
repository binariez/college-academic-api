using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface ICourseEnrollmentRepository
    {
        Task<bool> Exists(int id);

        Task<CourseEnrollment?> AlreadyEnrolled(int studentId, int courseClassId);

        Task<CourseEnrollment> CreateAsync(CourseEnrollment enrollment);

        Task<IEnumerable<CourseEnrollment>> GetAllAsync();

        Task DeleteAsync(CourseEnrollment enrollment);

        Task<CourseEnrollment?> GetByIdAsync(int id);

        Task<IEnumerable<CourseEnrollment>> GetByStudentIdAsync(int studentId);

        Task SaveChangesAsync();
    }
}
