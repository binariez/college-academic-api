using College.Api.Shared.Enums;

namespace College.Api.Models
{
    // Enrollment a.k.a KRS
    // This entity bridges between `Student` and `CourseClass` entity
    // Which will indirectly form a many-to-many relationship between both entities above
    // With additional details such as enrollment date and status
    public class CourseEnrollment
    {
        public int Id { get; set; }

        // Form a relation with `Student` entity
        // 1 to many relation: 1 Student can have many CourseEnrollments
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        // Form a relation with `CourseClass` entity
        // 1 to many relation: 1 CourseClass can have many CourseEnrollments
        public int CourseClassId { get; set; }
        public CourseClass CourseClass { get; set; } = null!;

        public DateTime EnrolledAt { get; set; }

        public EnrollmentStatus EnrollmentStatus { get; set; }
    }
}
