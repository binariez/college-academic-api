using College.Api.Shared.Enums;

namespace College.Api.DTOs.Student
{
    public record StudentResponseDto
    (
        int Id,
        string FullName,
        DateOnly DateOfBirth,
        Gender Gender,
        string Religion,
        string Address,
        string PhoneNumber,
        string EmergencyContactPhone,
        string Email,
        int Majorid
    );
}
