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
            // Validate major existence
            if (await majorRepo.Exists(majorId) == null)
                throw new Exception("The choosen major does not exist!");

            int? prerequisiteId = requestDto.PrerequisiteCourseId;

            if (prerequisiteId == 0) prerequisiteId = null;

            // Validate prerequisite course existence
            if (prerequisiteId.HasValue)
            {
                var exists = await courseRepo.Exists(prerequisiteId.Value);

                if (exists == null)
                    throw new Exception("The choosen prerequisite course does not exist!");
            }

            var course = requestDto.ToClassFromRequestDto(majorId);

            course.PrerequisiteCourseId = prerequisiteId;

            var result = await courseRepo.CreateAsync(course);

            return result.ToResponseDto();
        }

        public async Task<CourseResponseDto?> DeleteAsync(int id)
        {
            var deletedObject = await courseRepo.DeleteAsync(id);

            return deletedObject?.ToResponseDto();
        }

        public async Task<IEnumerable<CourseResponseDto>> GetAllAsync()
        {
            var courses = await courseRepo.GetAllAsync();

            return courses.Select(c => c.ToResponseDto());
        }

        public async Task<CourseResponseDto?> GetByIdAsync(int id)
        {
            var course = await courseRepo.GetByIdAsync(id);

            return course?.ToResponseDto();
        }

        public async Task<CourseResponseDto?> UpdateAsync(int id, CourseRequestDto requestDto)
        {
            var updatedObject = new Course
            {
                Id = id,
                Code = requestDto.Code,
                Name = requestDto.Name,
                SKS = requestDto.SKS,
                MinimumSemester = requestDto.MinimumSemester,
                MajorId = requestDto.MajorId,
                PrerequisiteCourseId = requestDto.PrerequisiteCourseId
            };

            var result = await courseRepo.UpdateAsync(updatedObject);

            return result?.ToResponseDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
