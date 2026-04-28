using College.Api.Models;
using College.Api.Persistence;
using College.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace College.Api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Student> CreateAsync(Student studentModel)
        {
            await context.Students.AddAsync(studentModel);

            await context.SaveChangesAsync();

            return studentModel;
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            var studentObject = context.Students.FirstOrDefault(s => s.Id == id);

            if (studentObject == null) return null;

            context.Students.Remove(studentObject);

            await context.SaveChangesAsync();

            return studentObject;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public async Task<Student?> UpdateAsync(Student student)
        {
            var studentFromDb = await context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);

            if (studentFromDb == null) return null;

            context.Entry(studentFromDb).CurrentValues.SetValues(student);

            await context.SaveChangesAsync();

            return studentFromDb;
        }
    }
}
