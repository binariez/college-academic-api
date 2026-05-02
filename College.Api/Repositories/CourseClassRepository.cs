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

            await context.SaveChangesAsync();

            return courseClass;
        }

        public async Task<CourseClass?> DeleteAsync(int id)
        {
            var courseClassObject = await context.CourseClasses.FindAsync(id);

            if (courseClassObject == null) return null;

            context.CourseClasses.Remove(courseClassObject);

            await context.SaveChangesAsync();

            return courseClassObject;
        }

        public Task<List<CourseClass>> GetAllAsync()
        {
            return context.CourseClasses.ToListAsync();
        }

        public async Task<CourseClass?> GetByIdAsync(int id)
        {
            var courseClassObject = await context.CourseClasses.FindAsync(id);

            if (courseClassObject == null) return null;

            return courseClassObject;
        }

        public async Task<CourseClass?> UpdateAsync(CourseClass courseClass)
        {
            var courseClassFromDb = await context.CourseClasses.FindAsync(courseClass.Id);

            if (courseClassFromDb == null) return null;

            context.Entry(courseClassFromDb).CurrentValues.SetValues(courseClass);

            await context.SaveChangesAsync();

            return courseClassFromDb;
        }
    }
}
