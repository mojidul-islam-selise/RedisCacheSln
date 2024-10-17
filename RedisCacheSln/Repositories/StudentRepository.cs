using ResisCacheSln.Models;
using Microsoft.EntityFrameworkCore;

namespace ResisCacheSln.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(
            ApplicationDbContext dbContext
            )
        {
            _dbContext = dbContext;
        }
        public async Task<Student> AddStudent(Student student)
        {
            await _dbContext.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public Task<Student> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public Task<Student> UpdateStudent(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
