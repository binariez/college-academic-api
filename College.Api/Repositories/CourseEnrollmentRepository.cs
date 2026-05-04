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

        public async Task<bool> Exists(int id)
        {
            return await context.CourseEnrollments.AnyAsync(ce => ce.Id == id);
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

            await SaveChangesAsync();

            return enrollment;
        }

        public async Task DeleteAsync(CourseEnrollment enrollment)
        {
            context.CourseEnrollments.Remove(enrollment);

            await SaveChangesAsync();
        }

        public async Task<CourseEnrollment?> GetByIdAsync(int id)
        {
            var result = context.CourseEnrollments
                .Where(ce => ce.Id == id)
                .Include(ce => ce.Student)
                .Include(ce => ce.CourseClass)
                .ThenInclude(cc => cc.Course);

            return await result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseEnrollment>> GetByStudentIdAsync(int studentId)
        {
            var result = context.CourseEnrollments
                .AsNoTracking()
                .Where(ce => ce.StudentId == studentId)
                .Include(ce => ce.Student)
                .Include(ce => ce.CourseClass)
                .ThenInclude(cc => cc.Course);

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<CourseEnrollment>> GetAllAsync()
        {
            var result = context.CourseEnrollments
                .AsNoTracking()
                .Include(ce => ce.Student)
                .Include(ce => ce.CourseClass)
                .ThenInclude(cc => cc.Course);

            return await result.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}