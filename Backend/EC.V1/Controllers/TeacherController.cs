using Data.Interface;
using Data.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<List<TeacherTypeResult>> GetAllAsync()
        {
            return await _teacherService.GetAllAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<TeacherTypeResult> GetByIdAsync(int id)
        {
            return await _teacherService.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<TeacherTypeResult> CreateAsync(TeacherTypeInput create)
        {
            return await _teacherService.CreateAsync(create);
        }
        [HttpPut("{id:int}")]
        public async Task<TeacherTypeResult> UpdateAsync(int id, TeacherTypeInput update)
        {
            return await _teacherService.UpdateAsync(id, update);
        }
        [HttpDelete("{id:int}")]
        public async Task DeleteAsync(int id)
        {
            await _teacherService.DeleteAsync(id);
        }


    }
}
