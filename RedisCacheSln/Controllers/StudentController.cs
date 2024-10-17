using Microsoft.AspNetCore.Mvc;
using RedisCacheSln.Services;
using ResisCacheSln.Models;
using ResisCacheSln.Repositories;

namespace RedisCacheSln.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRadisCacheService _radisCacheService;
        public StudentController(
            IStudentRepository studentRepository,
            IRadisCacheService radisCacheService
            )
        {
            _studentRepository = studentRepository;
            _radisCacheService = radisCacheService;
        }

        [HttpGet("students")]
        public IEnumerable<Student> Get()
        {
            var cacheData = _radisCacheService.GetCacheData<IEnumerable<Student>>("student");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            cacheData = _studentRepository.GetStudents().Result;
            _radisCacheService.SetCacheData<IEnumerable<Student>>("student", cacheData, expirationTime);
            return cacheData;
        }

        [HttpGet("student")]
        public Student Get(int id)
        {
            Student filteredData;
            var cacheData = _radisCacheService.GetCacheData<IEnumerable<Student>>("student");
            if (cacheData != null)
            {
                filteredData = cacheData.Where(x => x.Id == id).FirstOrDefault();
                return filteredData;
            }
            filteredData = _studentRepository.GetStudentById(id).Result;
            return filteredData;
        }

        [HttpPost("addstudent")]
        public async Task<Student> Post(Student student)
        {
            var obj = await _studentRepository.AddStudent(student);
            _radisCacheService.DeleteCacheData("student");
            return obj;
        }
        [HttpPut("updatestudent")]
        public void Put(Student student)
        {
            _studentRepository.UpdateStudent(student.Id, student);
            _radisCacheService.DeleteCacheData("student");
        }
        [HttpDelete("deletestudent")]
        public void Delete(int Id)
        {
            _studentRepository.DeleteStudent(Id);
            _radisCacheService.DeleteCacheData("student");
        }
    }
}
