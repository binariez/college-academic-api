using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface ICourseEnrollmentRepository
    {
        Task<bool> Exists(int id);

        Task<CourseEnrollment?> AlreadyEnrolled(int studentId, int courseClassId);

        Task<CourseEnrollment> CreateAsync(CourseEnrollment enrollment);

        Task<List<CourseEnrollment>> GetAllAsync();

        Task<CourseEnrollment?> DeleteAsync(CourseEnrollment enrollment);

        Task<CourseEnrollment?> UpdateAsync(CourseEnrollment enrollment);

        Task<CourseEnrollment?> GetByIdAsync(int id);

        Task<List<CourseEnrollment>> GetByStudentIdAsync(int studentId);
    }
}
