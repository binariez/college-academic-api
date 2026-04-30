using College.Api.Models;
using College.Api.Persistence;
using College.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace College.Api.Repositories
{
    public class CourseEnrollmentRepository : ICourseEnrollmentRepository
    {
        private readonly AppDbContext context;

        public CourseEnrollmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<CourseEnrollment?> AlreadyEnrolled(int studentId, int courseClassId)
        {
            return await context.CourseEnrollments
                .FirstOrDefaultAsync(x =>
                x.StudentId == studentId &&
                x.CourseClassId == courseClassId);
        }

        public async Task<CourseEnrollment> CreateAsync(CourseEnrollment enrollment)
        {
            await context.CourseEnrollments.AddAsync(enrollment);

            await context.SaveChangesAsync();

            return enrollment;
        }

        public async Task<CourseEnrollment?> DeleteAsync(CourseEnrollment enrollment)
        {
            var fromDb = await context.CourseEnrollments.FindAsync(enrollment.Id);

            if (fromDb == null) return null;

            context.CourseEnrollments.Remove(enrollment);

            await context.SaveChangesAsync();

            return fromDb;
        }

        public async Task<CourseEnrollment?> GetByIdAsync(int id)
        {
            return await context.CourseEnrollments.FindAsync(id);
        }

        public async Task<List<CourseEnrollment>> GetByStudentIdAsync(int studentId)
        {
            var result = context.CourseEnrollments
                //.Include(x => x.CourseClass.Name)
                .Where(x => x.StudentId == studentId)
                .OrderByDescending(x => x.EnrolledAt);

            return await result.ToListAsync();
        }
    }
}