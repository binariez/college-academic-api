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

            var newObject = await studentRepo.CreateAsync(fromDto);

            return newObject.ToResponseDto();
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
            var student = await studentRepo.GetByIdAsync(id);

            if (student == null)
                throw new NotFoundException($"Student with id: {id} does not exist.");

            if (await majorRepo.Exists(requestDto.MajorId) == false)
                throw new NotFoundException($"The choosen major with id: {requestDto.MajorId} does not exist.");

            // Map changes
            student.FullName = requestDto.FullName;
            student.DateOfBirth = requestDto.DateOfBirth;
            student.Gender = requestDto.Gender;
            student.Religion = requestDto.Religion;
            student.Address = requestDto.Address;
            student.PhoneNumber = requestDto.PhoneNumber;
            student.EmergencyContactPhone = requestDto.EmergencyContactPhone;
            student.Email = requestDto.Email;
            student.MajorId = requestDto.MajorId;

            await studentRepo.SaveChangesAsync();

            return student.ToResponseDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
