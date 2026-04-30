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
            var fromDto = requestDto.ToMajorFromMajorDto();

            var newObject = await majorRepo.CreateAsync(fromDto);

            return newObject.ToMajorDto();
        }

        public async Task<MajorResponseDto?> DeleteAsync(int id)
        {
            var deletedObject = await majorRepo.DeleteAsync(id);

            return deletedObject?.ToMajorDto();
        }

        public async Task<IEnumerable<MajorResponseDto>> GetAllAsync()
        {
            var result = await majorRepo.GetAllAsync();

            return result.Select(m => m.ToMajorDto());
        }

        public async Task<MajorResponseWithStudentDto?> GetByIdAsync(int id)
        {
            var result = await majorRepo.GetByIdAsync(id);

            return result?.ToMajorDetailDto();
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
