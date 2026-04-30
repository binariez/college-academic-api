using College.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace College.Api.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseClass> CourseClasses => Set<CourseClass>();
    public DbSet<CourseEnrollment> CourseEnrollments => Set<CourseEnrollment>();
    public DbSet<Major> Majors => Set<Major>();
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure 1(Major) to many(Student) relationship
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Major)
            .WithMany(m => m.Students)
            .HasForeignKey(s => s.MajorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure 1(Major) to many(Course) relationship
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Major)
            .WithMany(m => m.Courses)
            .HasForeignKey(c => c.MajorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure 1(Course) to many(CourseClass) relationship
        modelBuilder.Entity<CourseClass>()
            .HasOne(cc => cc.Course)
            .WithMany(c => c.CourseClasses)
            .HasForeignKey(cc => cc.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Course self referencing
        modelBuilder.Entity<Course>()
            .HasOne(c => c.PrerequisiteCourse)
            .WithMany()
            .HasForeignKey(c => c.PrerequisiteCourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure 1(CourseClass) to many(CourseEnrollment) relationship
        modelBuilder.Entity<CourseEnrollment>()
            .HasOne(ce => ce.CourseClass)
            .WithMany(cc => cc.CourseEnrollments)
            .HasForeignKey(ce => ce.CourseClassId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure 1(Student) to many(CourseEnrollment) relationship
        modelBuilder.Entity<CourseEnrollment>()
            .HasOne(ce => ce.Student)
            .WithMany(s => s.CourseEnrollments)
            .HasForeignKey(ce => ce.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    // Convert all enums to their representative name string
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Enum>()
            .HaveConversion<string>();
    }
}
