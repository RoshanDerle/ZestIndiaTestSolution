using ZestIndiaTest.Models;
using ZestIndiaTest.StudentRespository.Interfaces;
using ZestIndiaTest.StudentServices.Interface;

namespace ZestIndiaTest.StudentServices
{
    using Microsoft.Extensions.Logging;

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repo,
                              ILogger<StudentService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<List<Student>> GetAll()
        {
            try
            {
                var students = await _repo.GetAllStudentsAsync();

                if (students == null || !students.Any())
                {
                    _logger.LogWarning("No students found");
                    return new List<Student>();
                }

                return students;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAll service");
                throw;
            }
        }

        public async Task<int?> Add(Student student)
        {
            try
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student));

                 return await _repo.AddStudentAsync(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Add service");
                throw;
            }
        }

        public async Task<int> Update(Student student)
        {
            try
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student));

                return await _repo.UpdateStudentDeatailsAsync(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Update service");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Invalid student id");

                await _repo.DeleteStudentAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Delete service");
                throw;
            }
        }
    }
}
