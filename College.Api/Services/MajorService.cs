using College.Api.DTOs.Major;
using College.Api.Mappers;
using College.Api.Models;
using College.Api.Repositories.Interfaces;
using College.Api.Services.Interfaces;

namespace College.Api.Services
{
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository majorRepo;

        public MajorService(IMajorRepository majorRepo)
        {
            this.majorRepo = majorRepo;
        }


        //-------------------------
        // Begin of CRUD operations
        //-------------------------

        public async Task<MajorResponseDto> CreateAsync(MajorRequestDto requestDto)
        {
            var major = requestDto.ToMajorFromMajorDto();

            await majorRepo.CreateAsync(major);

            return major.ToMajorDto();
        }

        public async Task<Major?> DeleteAsync(int id)
        {
            return await majorRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<MajorResponseDto>> GetAllAsync()
        {
            var majors = await majorRepo.GetAllAsync();

            return majors.Select(m => m.ToMajorDto());
        }

        public async Task<MajorResponseWithStudentDto?> GetByIdAsync(int id)
        {
            var major = await majorRepo.GetByIdAsync(id);

            return major?.ToMajorDetailDto();
        }

        public async Task<MajorResponseDto?> UpdateAsync(int id, MajorRequestDto requestDto)
        {
            var updatedObject = new Major
            {
                Id = id,
                Code = requestDto.Code,
                Name = requestDto.Name,
            };

            var result = await majorRepo.UpdateAsync(updatedObject);

            return result?.ToMajorDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
