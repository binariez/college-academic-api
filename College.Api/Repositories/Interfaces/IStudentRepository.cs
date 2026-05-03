using College.Api.Models;

namespace College.Api.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<bool> Exists(int id);

        Task<Student> CreateAsync(Student student);

        Task DeleteAsync(Student student);

        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task SaveChangesAsync();
    }
}
