using College.Api.DTOs.Student;
using College.Api.Mappers;
using College.Api.Models;
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

        public async Task<StudentResponseDto> CreateAsync(int majorId, StudentRequestDto requestDto)
        {
            if (await majorRepo.Exists(majorId) == null)
                throw new Exception("The choosen Major does not exist!");

            var fromDto = requestDto.ToClassFromRequestDto(majorId);

            var newObject = await studentRepo.CreateAsync(fromDto);

            return newObject.ToResponseDto();
        }

        public async Task<StudentResponseDto?> DeleteAsync(int id)
        {
            var deletedObject = await studentRepo.DeleteAsync(id);

            return deletedObject?.ToResponseDto();
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            var result = await studentRepo.GetAllAsync();

            return result.Select(s => s.ToResponseDto());
        }

        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
            var result = await studentRepo.GetByIdAsync(id);

            return result?.ToResponseDto();
        }

        public async Task<StudentResponseDto?> UpdateAsync(int id, StudentRequestDto requestDto)
        {
            var updatedObject = new Student
            {
                Id = id,
                FullName = requestDto.FullName,
                DateOfBirth = requestDto.DateOfBirth,
                Gender = requestDto.Gender,
                Religion = requestDto.Religion,
                Address = requestDto.Address,
                PhoneNumber = requestDto.PhoneNumber,
                EmergencyContactPhone = requestDto.EmergencyContactPhone,
                Email = requestDto.Email,
                MajorId = requestDto.MajorId
            };

            var result = await studentRepo.UpdateAsync(updatedObject);

            return result?.ToResponseDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
