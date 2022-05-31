using Data.Interface;
using Data.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        [Route("RegisterStudent")]
        public async Task<AccountTypeResult> RegisterStudent([FromQuery] AccountTypeInput regis_student,
            [FromBody] StudentTypeInput student)
        {
            return await _accountService.RegisterStudent(regis_student, student);
        }
        [HttpPost]
        [Route("RegisterTeacher")]
        public async Task<AccountTypeResult> RegisterTeacher([FromQuery] AccountTypeInput regis_student,
           [FromBody] TeacherTypeInput teacher)
        {
            return await _accountService.RegisterTeacher(regis_student, teacher);
        }
        [HttpPost]
        [Route("RegisterManager")]
        public async Task<AccountTypeResult> RegisterManager([FromQuery] AccountTypeInput regis_student,
            [FromBody] ManagerTypeInput teacher)
        {
            return await _accountService.RegisterMananger(regis_student, teacher);
        }
    }
}
