using College.Api.DTOs.Major;
using College.Api.DTOs.Student;
using College.Api.Exceptions;
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
            var fromDto = requestDto.ToClassFromMajorDto();

            var created = await majorRepo.CreateAsync(fromDto);

            return created.ToResponseDto();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await majorRepo.GetByIdAsync(id);

            if (result == null)
                throw new NotFoundException($"Major with id: {id} does not exist!");

            await majorRepo.DeleteAsync(result);
        }

        public async Task<IEnumerable<MajorResponseDto>> GetAllAsync()
        {
            var result = await majorRepo.GetAllAsync();

            return result.Select(m => m.ToResponseDto());
        }

        public async Task<MajorResponseWithStudentDto?> GetByIdAsync(int id)
        {
            var result = await majorRepo.GetByIdAsync(id);

            if (result == null)
                throw new NotFoundException($"Major with id: {id} does not exist!");

            return new MajorResponseWithStudentDto
            (
                result.Id,
                result.Code,
                result.Name,
                result.Students.Select(s => new StudentSimpleDto(s.Id, s.FullName)).ToList()
            );
        }

        public async Task<MajorResponseDto?> UpdateAsync(int id, MajorRequestDto requestDto)
        {
            var updated = await majorRepo.GetByIdAsync(id);

            if (updated == null)
                throw new NotFoundException($"Major with id: {id} does not exist!");

            updated.Code = requestDto.Code;
            updated.Name = requestDto.Name;

            await majorRepo.SaveChangesAsync();

            return updated.ToResponseDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
