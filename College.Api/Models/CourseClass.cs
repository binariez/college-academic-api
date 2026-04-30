using College.Api.Shared.Enums;

namespace College.Api.Models
{
    public class CourseClass
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // Form a relation with `Course` entity
        // 1 to many relation: 1 Course can have many CourseClasses
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public int AcademicYear { get; set; }

        public SemesterType SemesterType { get; set; }

        // Form a relation with `CourseEnrollment` entity
        // 1 to many relation: 1 CourseClass can have many CourseEnrollments
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; } = [];
    }
}
