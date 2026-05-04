using College.Api.DTOs.CourseClass;
using College.Api.Exceptions;
using College.Api.Mappers;
using College.Api.Models;
using College.Api.Repositories.Interfaces;
using College.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
            if (await courseRepo.Exists(courseId) == false)
                throw new NotFoundException("The choosen course does not exist!");

            var fromDto = requestDto.ToClassFromRequestDto(courseId);

            var newObject = await ccRepo.CreateAsync(fromDto);

            return newObject.ToResponseDto();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await ccRepo.GetByIdAsync(id);

            if (deleted == null)
                throw new NotFoundException($"Enrollment with id: {id} does not exist!");

            await ccRepo.DeleteAsync(deleted);
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
            var updated = await ccRepo.GetByIdAsync(id);

            if (updated == null)
                throw new NotFoundException($"Enrollment with id: {id} does not exist!");

            if (await courseRepo.Exists(requestDto.CourseId) == false)
                throw new NotFoundException("The choosen course does not exist!");

            updated.CourseId = requestDto.CourseId;
            updated.AcademicYear = requestDto.AcademicYear;
            updated.Name = requestDto.Name;
            updated.SemesterType = requestDto.SemesterType;

            await ccRepo.SaveChangesAsync();

            return updated.ToResponseDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
