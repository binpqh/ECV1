using Data.Interface;
using Data.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<List<StudentTypeResult>> GetAllAsync()
        {
            return await _studentService.GetAllAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<StudentTypeResult> GetByIdAsync(int id)
        {
            return await _studentService.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<StudentTypeResult> CreateAsync(StudentTypeInput create)
        {
            return await _studentService.CreateAsync(create);
        }
        [HttpPut("{id:int}")]
        public async Task<StudentTypeResult> UpdateAsync(int id, StudentTypeInput update)
        {
            return await _studentService.UpdateAsync(id, update);
        }
        [HttpDelete("{id:int}")]
        public async Task DeleteAsync(int id)
        {
            await _studentService.DeleteAsync(id);
        }

    }
}
