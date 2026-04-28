using College.Api.DTOs.Student;
using College.Api.Mappers;
using College.Api.Models;
using College.Api.Repositories.Interfaces;
using College.Api.Services.Interfaces;

namespace College.Api.Services
{
    public class StudentService : IStudentService
    {
        private IMajorRepository majorRepo;
        private IStudentRepository studentRepo;

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
            if (await majorRepo.MajorExists(majorId) == false)
                throw new Exception("The choosen Major does not exist!");

            var student = requestDto.ToStudentFromStudentDto(majorId);

            var result = await studentRepo.CreateAsync(student);

            return result.ToStudentDto();
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            return await studentRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            var students = await studentRepo.GetAllAsync();

            return students.Select(s => s.ToStudentDto());
        }

        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
            var student= await studentRepo.GetByIdAsync(id);

            return student?.ToStudentDto();
        }

        public async Task<StudentResponseDto?> UpdateAsync(int id, StudentRequestDto requestDto)
        {
            var student = new Student
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

            var result = await studentRepo.UpdateAsync(student);

            return result?.ToStudentDto();
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
