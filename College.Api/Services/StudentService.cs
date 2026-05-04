using College.Api.DTOs.Student;
using College.Api.Exceptions;
using College.Api.Mappers;
using College.Api.Repositories.Interfaces;
using College.Api.Services.Interfaces;

namespace College.Api.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMajorRepository majorRepo;
        private readonly IStudentRepository studentRepo;

        public StudentService(IMajorRepository majorRepo, IStudentRepository studentRepo)
        {
            this.majorRepo = majorRepo;
            this.studentRepo = studentRepo;
        }
        

        //-------------------------
        // Begin of CRUD operations
        //-------------------------

        public async Task<StudentResponseDto> CreateAsync(StudentRequestDto requestDto)
        {
            if (await majorRepo.Exists(requestDto.MajorId) == false)
                throw new NotFoundException($"The choosen major with id: {requestDto.MajorId} does not exist!");

            var fromDto = requestDto.ToClassFromRequestDto(requestDto.MajorId);

            var created = await studentRepo.CreateAsync(fromDto);

            return created.ToResponseDto();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await studentRepo.GetByIdAsync(id);

            if (result == null)
                throw new NotFoundException($"Student with id: {id} does not exist!");

            await studentRepo.DeleteAsync(result);
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            var result = await studentRepo.GetAllAsync();

            return result.Select(s => s.ToResponseDto());
        }

        public async Task<StudentResponseDto> GetByIdAsync(int id)
        {
            var result = await studentRepo.GetByIdAsync(id);

            if (result == null)
                throw new NotFoundException($"Student with id: {id} does not exist!");

            return result.ToResponseDto();
        }

        public async Task<StudentResponseDto> UpdateAsync(int id, StudentRequestDto requestDto)
        {
            var updated = await studentRepo.GetByIdAsync(id);

            if (updated == null)
                throw new NotFoundException($"Student with id: {id} does not exist.");

            if (await majorRepo.Exists(requestDto.MajorId) == false)
                throw new NotFoundException($"The choosen major with id: {requestDto.MajorId} does not exist.");

            // Map changes
            updated.FullName = requestDto.FullName;
            updated.DateOfBirth = requestDto.DateOfBirth;
            updated.Gender = requestDto.Gender;
            updated.Religion = requestDto.Religion;
            updated.Address = requestDto.Address;
            updated.PhoneNumber = requestDto.PhoneNumber;
            updated.EmergencyContactPhone = requestDto.EmergencyContactPhone;
            updated.Email = requestDto.Email;
            updated.MajorId = requestDto.MajorId;

            await studentRepo.SaveChangesAsync();

            return updated.ToResponseDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
