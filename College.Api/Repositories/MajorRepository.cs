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

        public async Task<bool> Exists(int id)
        {
            return await context.Majors.AnyAsync(m => m.Id == id);
        }

        public async Task<Major> CreateAsync(Major major)
        {
            await context.Majors.AddAsync(major);

            await SaveChangesAsync();

            return major;
        }

        public async Task DeleteAsync(Major major)
        {
            context.Majors.Remove(major);

            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Major>> GetAllAsync()
        {
            return await context.Majors
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Major?> GetByIdAsync(int id)
        {
            var res = await context.Majors
                //.AsNoTracking() <- disabled this because still need to be tracked for update in service
                .Include(m => m.Students)
                .FirstOrDefaultAsync(m => m.Id == id);

            return res;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
