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

        public async Task<Major?> Exists(int id)
        {
            return await context.Majors.FindAsync(id);
        }

        public async Task<Major> CreateAsync(Major major)
        {
            await context.Majors.AddAsync(major);

            await context.SaveChangesAsync();

            return major;
        }

        public async Task<Major?> DeleteAsync(int id)
        {
            var majorObject = await Exists(id);

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
            var res = await Exists(id);
            return res;
        }

        public async Task<Major?> UpdateAsync(Major major)
        {
            var majorFromDb = await Exists(major.Id);

            if (majorFromDb == null) return null;

            context.Entry(majorFromDb).CurrentValues.SetValues(major);

            await context.SaveChangesAsync();

            return majorFromDb;
        }
    }
}
