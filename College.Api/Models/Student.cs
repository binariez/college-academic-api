using College.Api.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Api.Models;

public class Student //: BaseEntity
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string Religion { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string EmergencyContactPhone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly EnrollmentDate { get; set; }
    public StudentStatus Status { get; set; }
    public int CurrentSemester { get; set; }
    [Column(TypeName = "decimal(3,2)")]
    public decimal GPA { get; set; }

    // Form a relation to `Major` entity
    // 1 to many relation: 1 Major can have many Students
    // Storing MajorId as foreign key.
    // Also keep major class as a navigation
    public int MajorId { get; set; }
    public Major Major { get; set; } = null!;

    // Form a relation with `CourseEnrollment` entity
    // 1 to many relation: 1 Student can have many CourseEnrollments
    public ICollection<CourseEnrollment> CourseEnrollments { get; set; } = [];




    // TODO:
    // Form a relation to `Course` class
    // Many to many relation:
    // 1 Student can have many Courses
    // And 1 Course can have many Students
    //public ICollection<Course> CurrentlyTakenCourses { get; set; } = [];



    // TODO: Move these to other classes when possible
    //public ICollection<Course> CompletedCourses { get; set; } = [];
    //public int TotalCredits { get; set; }
    //public DateOnly GraduationDate { get; set; }
}