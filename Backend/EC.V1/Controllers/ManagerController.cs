using Data.Interface;
using Data.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        [HttpGet("{id:int}")]
        public async Task<ManagerTypeResult> GetByIdAsync(int id)
        {
            return await _managerService.GetByIdAsync(id);
        }
        [HttpGet]
        public async Task<List<ManagerTypeResult>> GetAllAsync()
        {
            return await _managerService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ManagerTypeResult> CreateAsync(ManagerTypeInput create)
        {
            return await _managerService.CreateAsync(create);
        }
        [HttpPut("{id:int}")]
        public async Task<ManagerTypeResult> UpdateAsync(int id, ManagerTypeInput input)
        {
            return await _managerService.UpdateAsync(id, input);
        }
        [HttpDelete("{id:int}")]
        public async Task DeleteAsync(int id)
        {
            await _managerService.DeleteAsync(id);
        }
    }
}
