using College.Api.DTOs.Major;
using College.Api.Models;

namespace College.Api.Mappers
{
    public static class MajorMapper
    {
        public static MajorResponseDto ToResponseDto(this Major majorModel)
        {
            return new MajorResponseDto
            (
                majorModel.Id,
                majorModel.Code,
                majorModel.Name
            );
        }

        //public static MajorResponseWithStudentDto ToMajorDetailDto(this Major majorModel)
        //{
        //    return new MajorResponseWithStudentDto
        //    (
        //        majorModel.Id,
        //        majorModel.Code,
        //        majorModel.Name,
        //        majorModel.Students.Select(s => s.ToSimpleStudentDto()).ToList()
        //    );
        //}

        public static Major ToClassFromMajorDto(this MajorRequestDto majorDto)
        {
            return new Major
            {
                Code = majorDto.Code,
                Name = majorDto.Name
            };
        }
    }
}
