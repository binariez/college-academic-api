using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> CreateAsync(Student student);

        Task<Student?> DeleteAsync(int id);

        Task<List<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task<Student?> UpdateAsync(Student student);
    }
}
