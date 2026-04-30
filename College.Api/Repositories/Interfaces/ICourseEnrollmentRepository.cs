using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface ICourseEnrollmentRepository
    {
        Task<CourseEnrollment?> AlreadyEnrolled(int studentId, int courseClassId);

        Task<CourseEnrollment> CreateAsync(CourseEnrollment enrollment);

        Task<CourseEnrollment?> DeleteAsync(CourseEnrollment enrollment);

        Task<CourseEnrollment?> GetByIdAsync(int id);

        Task<List<CourseEnrollment>> GetByStudentIdAsync(int studentId);
    }
}
