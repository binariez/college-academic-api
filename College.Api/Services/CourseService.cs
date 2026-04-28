using College.Api.DTOs.Course;
using College.Api.Mappers;
using College.Api.Models;
using College.Api.Repositories.Interfaces;
using College.Api.Services.Interfaces;

namespace College.Api.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepo;

        private readonly IMajorRepository majorRepo;

        public CourseService(ICourseRepository courseRepo, IMajorRepository majorRepo)
        {
            this.courseRepo = courseRepo;
            this.majorRepo = majorRepo;
        }


        //-------------------------
        // Begin of CRUD operations
        //-------------------------

        public async Task<CourseResponseDto> CreateAsync(int majorId, CourseRequestDto requestDto)
        {
            if (await majorRepo.MajorExists(majorId) == false)
                throw new Exception("The choosen major does not exist!");

            var course = requestDto.ToCourseFromCourseDto(majorId);

            var result = await courseRepo.CreateAsync(course);

            return result.ToCourseDto();
        }

        public async Task<Course?> DeleteAsync(int id)
        {
            return await courseRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<CourseResponseDto>> GetAllAsync()
        {
            var courses = await courseRepo.GetAllAsync();

            return courses.Select(c => c.ToCourseDto());
        }

        public async Task<CourseResponseDto?> GetByIdAsync(int id)
        {
            var course = await courseRepo.GetByIdAsync(id);

            return course?.ToCourseDto();
        }

        public async Task<CourseResponseDto?> UpdateAsync(int id, CourseRequestDto requestDto)
        {
            var course = new Course
            {
                Id = id,
                Code = requestDto.Code,
                Name = requestDto.Name,
                SKS = requestDto.SKS,
                MinimumSemester = requestDto.MinimumSemester,
                MajorId = requestDto.MajorId
            };

            var result = await courseRepo.UpdateAsync(course);

            return result?.ToCourseDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
