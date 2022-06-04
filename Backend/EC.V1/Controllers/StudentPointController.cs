using Data.Interface;
using Data.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPointController : ControllerBase
    {
        private readonly IStudentPointService _studentPointService;
        public StudentPointController(IStudentPointService studentPointService)
        {
            _studentPointService = studentPointService;
        }
        [HttpPost]
        public async Task<StudentPointTypeResult> CreateStudentPoint(StudentPointTypeInput studentPoint)
        {
            return await _studentPointService.CreateStudentPoint(studentPoint);
        }
        [HttpPut("{id:int}")]
        public async Task<StudentPointTypeResult> UpdateStudentPoint(int id, StudentPointTypeInput studentPoint)
        {
            return await _studentPointService.UpdateStudentPoint(id, studentPoint);
        }
        [HttpDelete("{id:int}")]
        public async Task DeleteStudentPoint(int id)
        {
            await _studentPointService.DeleteStudentPoint(id);
        }
        [HttpGet]
        public async Task<List<StudentPointTypeResult>> GetAllStudentPoint()
        {
            return await _studentPointService.GetAllStudentPoint();
        }
    }
}
