using College.Api.DTOs.CourseEnrollment;
using College.Api.Mappers;
using College.Api.Repositories.Interfaces;
using College.Api.Services.Interfaces;
using College.Api.Shared.Enums;

namespace College.Api.Services
{
    public class CourseEnrollmentService : ICourseEnrollmentService
    {
        private readonly ICourseEnrollmentRepository enrollmentRepo;

        private readonly IStudentRepository studentRepo;

        private readonly ICourseClassRepository courseClassRepo;

        public CourseEnrollmentService(
            ICourseEnrollmentRepository enrollmentRepo,
            IStudentRepository studentRepo,
            ICourseClassRepository courseClassRepo
            )
        {
            this.enrollmentRepo = enrollmentRepo;

            this.studentRepo = studentRepo;

            this.courseClassRepo = courseClassRepo;
        }

        //-------------------------
        // Begin of CRUD operations
        //-------------------------

        public async Task<CourseEnrollmentResponseDto> CreateAsync(CourseEnrollmentRequestDto requestDto)
        {
            if (await studentRepo.Exists(requestDto.StudentId) == false)
                throw new Exception("Student does not exist!");

            if (await courseClassRepo.Exists(requestDto.CourseClassId) == false) 
                throw new Exception("Course class does not exist!");

            var alreadyEnrolled = await enrollmentRepo.AlreadyEnrolled(requestDto.StudentId, requestDto.CourseClassId);

            if (alreadyEnrolled != null) throw new Exception("This student already enrolled for this class!");

            // TODO: check course prerequisite first before a student able to enroll the particular course class

            var fromDto = requestDto.ToClassFromRequestDto();

            var newObject = await enrollmentRepo.CreateAsync(fromDto);

            return newObject.ToResponseDto();
        }

        // Hard delete (intended for admin usage)
        public async Task<CourseEnrollmentResponseDto?> DeleteAsync(int courseEnrollmentId)
        {
            var deletedObject = await enrollmentRepo.GetByIdAsync(courseEnrollmentId);

            if (deletedObject == null) return null;

            await enrollmentRepo.DeleteAsync(deletedObject);

            return deletedObject.ToResponseDto();
        }

        // Soft delete (intended for student usage)
        public async Task<CourseEnrollmentResponseDto?> DropEnrollmentAsync(int courseEnrollmentId)
        {
            var existing = await enrollmentRepo.GetByIdAsync(courseEnrollmentId);

            if (existing == null) return null;

            if (existing.EnrollmentStatus == EnrollmentStatus.Completed)
                throw new Exception("Cannot drop because this enrollment has already been completed!");

            existing.EnrollmentStatus = EnrollmentStatus.Dropped;

            await enrollmentRepo.UpdateAsync(existing);

            return existing.ToResponseDto();
        }

        // Ideally, this should be triggered automatically by the system when a student has completed the enrollment
        public async Task<CourseEnrollmentResponseDto?> CompleteEnrollmentAsync(int courseEnrollmentId)
        {
            var existing = await enrollmentRepo.GetByIdAsync(courseEnrollmentId);

            if (existing == null) return null;

            if (existing.EnrollmentStatus == EnrollmentStatus.Dropped)
                throw new Exception("Cannot complete an enrollment that has been dropped. Please the status to enrolled first!");

            existing.EnrollmentStatus = EnrollmentStatus.Completed;

            await enrollmentRepo.UpdateAsync(existing);

            return existing.ToResponseDto();
        }

        // Using this if a student wants to re-enroll an enrollment that has been dropped.
        // So, rather than creating a new enrollment, just update the enrollment status.
        public async Task<CourseEnrollmentResponseDto?> ReEnrollAsync(int courseEnrollmentId)
        {
            var existing = await enrollmentRepo.GetByIdAsync(courseEnrollmentId);

            if (existing == null) return null;

            if (existing.EnrollmentStatus == EnrollmentStatus.Completed)
                throw new Exception("Cannot re-enroll. Enrollment has already been completed!");

            existing.EnrollmentStatus = EnrollmentStatus.Enrolled;
            existing.EnrolledAt = DateTime.Now;

            await enrollmentRepo.UpdateAsync(existing);

            return existing.ToResponseDto();
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

        public async Task<IEnumerable<CourseEnrollmentResponseDto>> GetAllAsync()
        {
            var result = await enrollmentRepo.GetAllAsync();

            return result.Select(r => r.ToResponseDto());
        }

        //-------------------------
        // End of CRUD operations
        //-------------------------
    }
}
