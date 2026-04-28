using College.Api.Models;
using College.Api.Persistence;
using College.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace College.Api.Repositories
{
    public class MajorRepository : IMajorRepository
    {
        private readonly AppDbContext context;

        public MajorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<bool> MajorExists(int id)
        {
            return context.Majors.AnyAsync(m => m.Id == id);
        }

        public async Task<Major> CreateAsync(Major major)
        {
            await context.Majors.AddAsync(major);

            await context.SaveChangesAsync();

            return major;
        }

        public async Task<Major?> DeleteAsync(int id)
        {
            var majorObject = await context.Majors.FirstOrDefaultAsync(m => m.Id == id);

            if (majorObject == null) return null;

            context.Majors.Remove(majorObject);

            await context.SaveChangesAsync();

            return majorObject;
        }

        public async Task<List<Major>> GetAllAsync()
        {
            return await context.Majors.ToListAsync();
        }

        public async Task<Major?> GetByIdAsync(int id)
        {
            var res =  await context.Majors.Include(m => m.Students).FirstOrDefaultAsync(m => m.Id == id);
            return res;
        }

        public async Task<Major?> UpdateAsync(Major major)
        {
            var majorFromDb = await context.Majors.FirstOrDefaultAsync(m => m.Id == major.Id);

            if (majorFromDb == null) return null;

            context.Entry(majorFromDb).CurrentValues.SetValues(major);

            await context.SaveChangesAsync();

            return majorFromDb;
        }
    }
}
