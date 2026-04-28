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

        public async Task<Course?> Exists(int id)
        {
            return await context.Courses.FindAsync(id);
        }

        public async Task<Course> CreateAsync(Course course)
        {
            await context.AddAsync(course);

            await context.SaveChangesAsync();

            return course;
        }

        public async Task<Course?> DeleteAsync(int id)
        {
            var courseObject = await Exists(id);

            if (courseObject == null) return null;

            context.Courses.Remove(courseObject);

            return courseObject;
        }

        public Task<List<Course>> GetAllAsync()
        {
            return context.Courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            var courseObject = await Exists(id);

            if (courseObject == null) return null;

            return courseObject;
        }

        public async Task<Course?> UpdateAsync(Course course)
        {
            var courseFromDb = await Exists(course.Id);

            if (courseFromDb == null) return null;

            context.Entry(courseFromDb).CurrentValues.SetValues(course);

            await context.SaveChangesAsync();

            return courseFromDb;
        }
    }
}
