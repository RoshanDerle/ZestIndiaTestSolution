using ZestIndiaTest.Models;

namespace ZestIndiaTest.StudentRespository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<int?> AddStudentAsync(Student student);
        Task<int> UpdateStudentDeatailsAsync(Student student);
        Task DeleteStudentAsync(int id);
    }
}
