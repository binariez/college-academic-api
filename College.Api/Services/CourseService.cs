using College.Api.DTOs.Course;
using College.Api.Exceptions;
using College.Api.Mappers;
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
            if (await majorRepo.Exists(majorId) == false)
                throw new NotFoundException("The choosen major does not exist!");

            int? prerequisiteId = requestDto.PrerequisiteCourseId;

            if (prerequisiteId == 0) prerequisiteId = null;

            // Validate prerequisite course existence
            if (prerequisiteId.HasValue)
            {
                var exists = await courseRepo.Exists(prerequisiteId.Value);

                if (exists == false)
                    throw new NotFoundException("The choosen prerequisite course does not exist!");
            }

            var fromDto = requestDto.ToClassFromRequestDto(majorId);

            fromDto.PrerequisiteCourseId = prerequisiteId;

            var created = await courseRepo.CreateAsync(fromDto);

            return created.ToResponseDto();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await courseRepo.GetByIdAsync(id);

            if (deleted == null)
                throw new NotFoundException($"Course with id: {id} does not exist");

            await courseRepo.DeleteAsync(deleted);
        }

        public async Task<IEnumerable<CourseResponseDto>> GetAllAsync()
        {
            var result = await courseRepo.GetAllAsync();

            return result.Select(c => c.ToResponseDto());
        }

        public async Task<CourseResponseDto?> GetByIdAsync(int id)
        {
            var result = await courseRepo.GetByIdAsync(id);

            return result?.ToResponseDto();
        }

        public async Task<CourseResponseDto?> UpdateAsync(int id, CourseRequestDto requestDto)
        {
            var updated = await courseRepo.GetByIdAsync(id);

            if (updated == null)
                throw new NotFoundException($"Course with id: {id} does not exist");

            if (await majorRepo.Exists(requestDto.MajorId) == false)
                throw new NotFoundException($"The choosen major with id: {requestDto.MajorId} does not exist.");

            int? prerequisiteId = requestDto.PrerequisiteCourseId;

            if (prerequisiteId == 0) prerequisiteId = null;

            // Validate prerequisite course existence
            if (prerequisiteId.HasValue)
            {
                var exists = await courseRepo.Exists(prerequisiteId.Value);

                if (exists == false)
                    throw new NotFoundException("The choosen prerequisite course does not exist!");
            }

            updated.Code = requestDto.Code;
            updated.Name = requestDto.Name;
            updated.SKS = requestDto.SKS;
            updated.MinimumSemester = requestDto.MinimumSemester;
            updated.MajorId = requestDto.MajorId;
            updated.PrerequisiteCourseId = prerequisiteId;

            await courseRepo.SaveChangesAsync();

            return updated.ToResponseDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
