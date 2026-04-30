using College.Api.DTOs.CourseEnrollment;
using College.Api.Mappers;
using College.Api.Repositories.Interfaces;
using College.Api.Services.Interfaces;

namespace College.Api.Services
{
    public class CourseEnrollmentService : ICourseEnrollmentService
    {
        private readonly ICourseEnrollmentRepository enrollmentRepo;

        public CourseEnrollmentService(ICourseEnrollmentRepository enrollmentRepo)
        {
            this.enrollmentRepo = enrollmentRepo;
        }

        public async Task<CourseEnrollmentResponseDto> CreateAsync(CourseEnrollmentRequestDto requestDto)
        {
            var exists = await enrollmentRepo.AlreadyEnrolled(requestDto.StudentId, requestDto.CourseClassId);

            if (exists != null)
                throw new Exception("This student already enrolled for this class!");

            // TODO: check course prerequisite first before a student able to enroll the particular course class
            // TODO: more strict validation steps like student exists or not

            var fromDto = requestDto.ToClassFromRequestDto();

            var enrollment = await enrollmentRepo.CreateAsync(fromDto);

            return enrollment.ToResponseDto();
        }

        public async Task<CourseEnrollmentResponseDto?> DeleteAsync(int courseEnrollmentId)
        {
            var enrollment = await enrollmentRepo.GetByIdAsync(courseEnrollmentId);

            if (enrollment == null) return null;

            await enrollmentRepo.DeleteAsync(enrollment);

            return enrollment.ToResponseDto();
        }

        public async Task<CourseEnrollmentResponseDto?> GetByIdAsync(int id)
        {
            var result = await enrollmentRepo.GetByIdAsync(id);

            return result?.ToResponseDto();
        }

        public async Task<IEnumerable<CourseEnrollmentResponseDto>> GetByStudentIdAsync(int studentId)
        {
            var result = await enrollmentRepo.GetByStudentIdAsync(studentId);

            return result.Select(r => r.ToResponseDto());
        }
    }
}
