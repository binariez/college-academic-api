using College.Api.Models;
using College.Api.Persistence;
using College.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace College.Api.Repositories
{
    /// <summary>
    /// After learning a bit deeper about repository pattern and then cleaning some code here,
    /// I think this repo class kinda looks useless that I thought I could just call these oneliners straight from service.
    /// But at the same time, I'm not even adding complex queries yet lol.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await context.Students.AnyAsync(s => s.Id == id);
        }

        public async Task<Student> CreateAsync(Student studentModel)
        {
            await context.Students.AddAsync(studentModel);

            await SaveChangesAsync();

            return studentModel;
        }

        public async Task DeleteAsync(Student student)
        {
            context.Students.Remove(student);

            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await context.Students
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
