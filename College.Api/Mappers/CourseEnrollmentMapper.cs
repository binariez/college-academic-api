using College.Api.DTOs.CourseEnrollment;
using College.Api.Models;

namespace College.Api.Mappers
{
    public static class CourseEnrollmentMapper
    {
        public static CourseEnrollmentResponseDto ToResponseDto(this CourseEnrollment enrollment)
        {
            return new CourseEnrollmentResponseDto
            (
                enrollment.Id,
                enrollment.StudentId,
                enrollment.Student.FullName,
                enrollment.CourseClassId,
                enrollment.CourseClass.Course.Name,
                enrollment.CourseClass.Name,
                enrollment.EnrolledAt,
                enrollment.EnrollmentStatus
            );
        }

        public static CourseEnrollment ToClassFromRequestDto(this CourseEnrollmentRequestDto requestDto)
        {
            return new CourseEnrollment
            {
                StudentId = requestDto.StudentId,
                CourseClassId = requestDto.CourseClassId,
                EnrolledAt = DateTime.Now,
                EnrollmentStatus = Shared.Enums.EnrollmentStatus.Enrolled
            };
        }
    }
}
