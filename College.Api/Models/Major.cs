namespace College.Api.Models
{
    // Major a.k.a program studi a.k.a jurusan
    public class Major
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        // Form a relation with `Student` entity
        // 1 to many relation: 1 Major can have many Students
        // List of students enrolled for this major
        public ICollection<Student> Students { get; set; } = [];

        // Form a relation to `Major` entity
        // 1 to many relation:
        // 1 Major can have many Courses
        public ICollection<Course> Courses { get; set; } = [];


        // TODO:
        // List of course which available for students pursuing this major
        //public List<Course> AvailableCourses { get; set; } = [];
    }
}