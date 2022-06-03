using Data.Interface;
using Data.Types;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }
        [HttpGet("{id:int}")]
        public async Task<ClassResult> GetbyIdAsync(int id)
        {
            return await _classService.GetAsync(id);
        }
        [HttpGet]
        public async Task<List<ClassResult>> GetAllAsync()
        {
            return await _classService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ClassResult> CreateAsync(ClassInput create)
        {
            return await _classService.CreateAsync(create);
        }
        [HttpPut("{id:int}")]
        public async Task<ClassResult> UpdateAsync(int id, ClassInput update)
        {
            return await _classService.UpdateAsync(id, update);
        }
        [HttpDelete("{id:int}")]
        public async Task DeleteAsync(int id)
        {
            await _classService.DeleteAsync(id);
        }
        
    }
}
