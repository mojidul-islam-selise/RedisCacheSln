using ResisCacheSln.Models;

namespace ResisCacheSln.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> AddStudent(Student student);
        Task<Student> DeleteStudent(int id);
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudents();
        Task<Student> UpdateStudent(int id, Student student);
    }
}
