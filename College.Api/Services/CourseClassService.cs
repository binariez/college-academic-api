using College.Api.DTOs.CourseClass;
using College.Api.Mappers;
using College.Api.Models;
using College.Api.Repositories.Interfaces;
using College.Api.Services.Interfaces;

namespace College.Api.Services
{
    public class CourseClassService : ICourseClassService
    {
        private readonly ICourseClassRepository ccRepo;

        private readonly ICourseRepository courseRepo;

        public CourseClassService(ICourseClassRepository ccRepo, ICourseRepository courseRepo)
        {
            this.ccRepo = ccRepo;
            this.courseRepo = courseRepo;
        }


        //-------------------------
        // Begin of CRUD operations
        //-------------------------

        public async Task<CourseClassResponseDto> CreateAsync(int courseId, CourseClassRequestDto requestDto)
        {
            if (courseRepo.Exists(courseId) == null)
                throw new Exception("The choosen course does not exist!");

            var fromDto = requestDto.ToClassFromRequestDto(courseId);

            var newObject = await ccRepo.CreateAsync(fromDto);

            return newObject.ToResponseDto();
        }

        public async Task<CourseClassResponseDto?> DeleteAsync(int id)
        {
            var deletedObject = await ccRepo.DeleteAsync(id);

            return deletedObject?.ToResponseDto();
        }

        public async Task<IEnumerable<CourseClassResponseDto>> GetAllAsync()
        {
            var result = await ccRepo.GetAllAsync();

            return result.Select(r => r.ToResponseDto());
        }

        public async Task<CourseClassResponseDto?> GetByIdAsync(int id)
        {
            var result = await ccRepo.GetByIdAsync(id);

            return result?.ToResponseDto();
        }

        public async Task<CourseClassResponseDto?> UpdateAsync(int id, CourseClassRequestDto requestDto)
        {
            var updatedObject = new CourseClass
            {
                Id = id,
                CourseId = requestDto.CourseId,
                AcademicYear = requestDto.AcademicYear,
                Name = requestDto.Name,
                SemesterType = requestDto.SemesterType
            };

            var result = await ccRepo.UpdateAsync(updatedObject);

            return result?.ToResponseDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
