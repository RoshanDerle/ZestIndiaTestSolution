using ZestIndiaTest.Models;

namespace ZestIndiaTest.StudentServices.Interface
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<int?> Add(Student student);
        Task<int> Update(Student student);
        Task Delete(int id);
    }
}
