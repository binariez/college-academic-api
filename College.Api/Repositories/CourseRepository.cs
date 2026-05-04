using College.Api.Models;
using College.Api.Persistence;
using College.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace College.Api.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext context;

        public CourseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await context.Courses.AnyAsync(c => c.Id == id);
        }

        public async Task<Course> CreateAsync(Course course)
        {
            await context.AddAsync(course);

            await context.SaveChangesAsync();

            return course;
        }

        public async Task DeleteAsync(Course course)
        {
            context.Courses.Remove(course);

            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await context.Courses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await context.Courses.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
