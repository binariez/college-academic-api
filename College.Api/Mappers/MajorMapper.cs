using College.Api.DTOs.Major;
using College.Api.DTOs.Student;
using College.Api.Models;

namespace College.Api.Mappers
{
    public static class MajorMapper
    {
        public static MajorResponseDto ToMajorDto(this Major majorModel)
        {
            return new MajorResponseDto
            (
                majorModel.Id,
                majorModel.Code,
                majorModel.Name
            );
        }

        public static MajorResponseWithStudentDto ToMajorDetailDto(this Major majorModel)
        {
            return new MajorResponseWithStudentDto
            (
                majorModel.Id,
                majorModel.Code,
                majorModel.Name,
                majorModel.Students.Select(s => s.ToSimpleStudentDto()).ToList()
            );
        }

        public static Major ToMajorFromMajorDto(this MajorRequestDto majorDto)
        {
            return new Major
            {
                Code = majorDto.Code,
                Name = majorDto.Name
            };
        }
    }
}
