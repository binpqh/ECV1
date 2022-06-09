using Data.Defined.Enum;
using Data.Interface;
using Data.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableController : ControllerBase
    {
        private readonly IClassService _classService;
        public TimeTableController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost("{id:int}")]
        public async Task TimeTable(int id, WeekdayEnum weekday)
        {
            await _classService.TimeTable(id, weekday);
        }
        [HttpGet("{id:int}")]
        public async Task<List<TimeTableTypeResult>> GetTimeTable(int id)
        {
            return await _classService.GetTimeTable(id);
        }
        [HttpDelete("{id:int}")]
        public async Task DeteleClassDay(int id, WeekdayEnum weekday)   
        {
            await _classService.DeteleClassDay(id, weekday);
        }
    }
}
