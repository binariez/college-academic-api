using College.Api.DTOs.CourseClass;
using College.Api.Models;

namespace College.Api.Mappers
{
    public static class CourseClassMapper
    {
        public static CourseClassResponseDto ToResponseDto(this CourseClass courseClass)
        {
            return new CourseClassResponseDto
            (
                courseClass.Id,
                courseClass.Name,
                courseClass.CourseId,
                courseClass.AcademicYear,
                courseClass.SemesterType
            );
        }

        public static CourseClass ToClassFromRequestDto(this CourseClassRequestDto requestDto, int courseId)
        {
            return new CourseClass
            {
                Name = requestDto.Name,
                CourseId = courseId,
                AcademicYear = requestDto.AcademicYear,
                SemesterType = requestDto.SemesterType
            };
        }
    }
}