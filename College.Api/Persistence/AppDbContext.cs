using College.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace College.Api.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Major> Majors => Set<Major>();
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Enum>()
            .HaveConversion<string>();
    }
}
