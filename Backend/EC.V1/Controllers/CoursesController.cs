using Data.Interface;
using Data.Types;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("{id:int}")]
        public async Task<CourseResult> GetbyIdAsync(int id)
        {
            return await _courseService.GetbyIdAsync(id);
        }
        [HttpGet]
        public async Task<List<CourseResult>> GetAllAsync()
        {
            return await _courseService.GetAllAsync();
        }
        [HttpPost]
        public async Task<CourseResult> CreateAsync(CourseInput create)
        {
            return await _courseService.CreateAsync(create);
        }
        [HttpPut("{id:int}")]
        public async Task<CourseResult> UpdateAsync(int id,CourseInput update)
        {
            return await _courseService.UpdateAsync(id,update);
        }
        [HttpDelete("{id:int}")]
        public async Task DeleteAsync(int id)
        {
            await _courseService.DeleteAsync(id);
        }
    }
}
