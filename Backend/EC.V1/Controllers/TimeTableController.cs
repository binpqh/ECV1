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
        public async Task TimeTable(int idclass, TimeTableInput input)
        {
            await _classService.TimeTable(idclass, input);
        }
        [HttpGet("{id:int}")]
        public async Task<List<TimeTableTypeResult>> GetTimeTable(int idclass)
        {
            return await _classService.GetTimeTable(idclass);
        }
        [HttpDelete("{id:int}")]
        public async Task DeteleClassDay(int idclass, WeekdayEnum weekday)
        {
            await _classService.DeteleClassDay(idclass, weekday);
        }
    }
}
