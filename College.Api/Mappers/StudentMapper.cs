using College.Api.DTOs.Student;
using College.Api.Models;

namespace College.Api.Mappers
{
    public static class StudentMapper
    {
        /// <summary>
        /// Using this to map Student data response for client based on response DTO structure
        /// </summary>
        public static StudentResponseDto ToStudentDto(this Student student)
        {
            return new StudentResponseDto
            (
                student.Id,
                student.FullName,
                student.DateOfBirth,
                student.Gender,
                student.Religion,
                student.Address,
                student.PhoneNumber,
                student.EmergencyContactPhone,
                student.Email,
                student.MajorId
            );
        }

        /// <summary>
        /// Using this to map simplified Student data for relational purposes.
        /// For example if we want to retreive detailed Major data,
        /// which we also want it to give Student list who enrolled for the particular Major.
        /// But we don't want to show full blown Student data that will make the response cluttered.
        /// Only retreive necessary data like student id and their full name.
        /// </summary>
        public static StudentSimpleDto ToSimpleStudentDto(this Student student)
        {
            return new StudentSimpleDto
            (
                student.Id,
                student.FullName
            );
        }

        public static Student ToStudentFromStudentDto(this StudentRequestDto requestDto, int majorId)
        {
            return new Student
            {
                FullName = requestDto.FullName,
                DateOfBirth = requestDto.DateOfBirth,
                Gender = requestDto.Gender,
                Religion = requestDto.Religion,
                Address = requestDto.Address,
                PhoneNumber = requestDto.PhoneNumber,
                EmergencyContactPhone = requestDto.EmergencyContactPhone,
                Email = requestDto.Email,
                MajorId = majorId
            };
        }
    }
}
