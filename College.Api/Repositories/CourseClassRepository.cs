using College.Api.Models;
using College.Api.Persistence;
using College.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace College.Api.Repositories
{
    public class CourseClassRepository : ICourseClassRepository
    {
        private readonly AppDbContext context;

        public CourseClassRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await context.CourseClasses.AnyAsync(c => c.Id == id);
        }

        public async Task<CourseClass> CreateAsync(CourseClass courseClass)
        {
            await context.CourseClasses.AddAsync(courseClass);

            await SaveChangesAsync();

            return courseClass;
        }

        public async Task DeleteAsync(CourseClass courseClass)
        {
            context.CourseClasses.Remove(courseClass);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseClass>> GetAllAsync()
        {
            return await context.CourseClasses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CourseClass?> GetByIdAsync(int id)
        {
            return await context.CourseClasses.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await SaveChangesAsync();
        }
    }
}
