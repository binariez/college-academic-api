namespace College.Api.Models;

public class Course
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int SKS { get; set; }
    public int MinimumSemester { get; set; }

    // Self reference if a course needs another course to be finished first
    public int? PrerequisiteCourseId { get; set; }
    public Course? PrerequisiteCourse { get; set; }

    // Form a relation to `Major` entity
    // 1 to many relation:
    // 1 Major can have many Courses
    public int MajorId { get; set; }
    public Major Major { get; set; } = null!;

    // Form a relation with `CourseClasses` entity
    // 1 to many relation: 1 Course can have many CourseClasses
    public ICollection<CourseClass> CourseClasses { get; set; } = [];
}