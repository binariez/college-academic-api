using College.Api.DTOs.Course;
using College.Api.Models;

namespace College.Api.Mappers
{
    public static class CourseMapper
    {
        public static CourseResponseDto ToCourseDto(this Course course)
        {
            return new CourseResponseDto
            (
                course.Id,
                course.Code,
                course.Name,
                course.SKS,
                course.MinimumSemester,
                course.MajorId
            );
        }

        public static Course ToCourseFromCourseDto(this CourseRequestDto requestDto, int majorId)
        {
            return new Course
            {
                Code = requestDto.Code,
                Name = requestDto.Name,
                SKS = requestDto.SKS,
                MinimumSemester = requestDto.MinimumSemester,
                MajorId = majorId
            };
        }
    }
}
