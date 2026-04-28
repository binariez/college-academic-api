namespace College.Api.Models;

public class Course
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int SKS { get; set; }
    public int MinimumSemester { get; set; }

    // Form a relation to `Major` entity
    // 1 to many relation:
    // 1 Major can have many Courses
    public int MajorId { get; set; }
    public Major Major { get; set; } = null!;



    // TODO:
    // Form a relation to `Student` entity
    // Many to many relation:
    // 1 Course can have many Students
    // And 1 Student can have many Courses
    //public ICollection<int> StudentId { get; set; }
    //public ICollection<Student> Students { get; set; } = [];

    
    
    // TODO: Apply course category enum
    //public CourseCategory CourseCategory { get; set; }
}