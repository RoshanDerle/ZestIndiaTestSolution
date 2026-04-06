using System.Data;
using System.Data.SqlClient;
using ZestIndiaTest.Models;
using ZestIndiaTest.StudentRespository.Interfaces;

namespace ZestIndiaTest.StudentRespository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(IConfiguration configuration, ILogger<StudentRepository> logger)
        {
            _connectionString = configuration?.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            try
            {
                var list = new List<Student>();

                using SqlConnection con = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("GetAllStudents", con);

                cmd.CommandType = CommandType.StoredProcedure;

                await con.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    list.Add(new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Course = reader["Course"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                    });
                }

                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllStudentsAsync");
                throw;
            }
        }

        public async Task<int?> AddStudentAsync(Student student)
        {
            try
            {
                using SqlConnection con = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("InsertNewStudent", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Course", student.Course);
                cmd.Parameters.AddWithValue("@CreatedBy", student.CreatedBy);

                await con.OpenAsync();

               int Id =  Convert.ToInt32(await cmd.ExecuteScalarAsync());

                if(Id > 0)
                    return Id;

                con.Close();

                return null;
              
            }             
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllStudentsAsync");
                throw;
            }
}

        public async Task<int> UpdateStudentDeatailsAsync(Student student)
        {
            try
            {
                using SqlConnection con = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("UpdateStudent", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Course", student.Course);

                await con.OpenAsync();
                return Convert.ToInt32(await cmd.ExecuteScalarAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllStudentsAsync");
                throw;
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting student");
                throw;
            }
        }
    }
}
