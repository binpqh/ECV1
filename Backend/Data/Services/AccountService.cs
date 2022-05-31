using Data.Defined.Enum;
using Data.Interface;
using Data.Tables;
using Data.Types;

namespace Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly ECV1DevContext _context;
        public AccountService(ECV1DevContext context)
        {
            _context = context;
        }
        public async Task<AccountTypeResult> RegisterMananger(AccountTypeInput regis_manager,ManagerTypeInput manager)
        {
            var managerAccount = new Account
            {
                Uid = regis_manager.Uid,
                Password = regis_manager.Password,
                Role = RoleEnum.Manager
            };
            var inforManager = new Manager
            {
                Name = manager.Name,
                Age = manager.Age,
                Address = manager.Address,
                Birthday = manager.Birthday,
                Phone = manager.Phone,
                Email = manager.Email,
                Status = Status.Active,
                IdAccount = managerAccount.Id
            };
            await _context.Accounts.AddAsync(managerAccount);
            await _context.Managers.AddAsync(inforManager);
            await _context.SaveChangesAsync();
            return new AccountTypeResult
            {
                Id = managerAccount.Id,
                Uid = managerAccount.Uid,
                Password = managerAccount.Password,
                Role = managerAccount.Role
            };
        }

        public async Task<AccountTypeResult> RegisterStudent(AccountTypeInput regis_student,StudentTypeInput student)
        {
            var studentAccount = new Account
            {
                Uid = regis_student.Uid,
                Password = regis_student.Password,
                Role = RoleEnum.Student
            };
            var inforStudent = new Student
            {
                Name = student.Name,
                Age = student.Age,
                Address = student.Address,
                Birthday = student.Birthday,
                Phone = student.Phone,
                Classkey = student.Classkey,
                Email = student.Email,
                Status = Status.Active,
                IdAccount = studentAccount.Id
            };
            await _context.Accounts.AddAsync(studentAccount);
            await _context.Students.AddAsync(inforStudent);
            await _context.SaveChangesAsync();
            return new AccountTypeResult
            {
                Id = studentAccount.Id,
                Uid = studentAccount.Uid,
                Password = studentAccount.Password,
                Role = studentAccount.Role
            };
        }

        public async Task<AccountTypeResult> RegisterTeacher(AccountTypeInput regis_teacher,TeacherTypeInput teacher)
        {
            var teacherAccount = new Account
            {
                Uid = regis_teacher.Uid,
                Password = regis_teacher.Password,
                Role = RoleEnum.Teacher
            };
            var inforTeacher = new Teacher
            {
                Name = teacher.Name,
                Age = teacher.Age,
                Address = teacher.Address,
                Birthday = teacher.Birthday,
                Phone = teacher.Phone,
                Classkey = teacher.Classkey,
                Email = teacher.Email,
                Status = Status.Active,
                IdAccount = teacherAccount.Id
            };
            await _context.Accounts.AddAsync(teacherAccount);
            await _context.Teachers.AddAsync(inforTeacher);
            await _context.SaveChangesAsync();
            return new AccountTypeResult
            {
                Id = teacherAccount.Id,
                Uid = teacherAccount.Uid,
                Password = teacherAccount.Password,
                Role = teacherAccount.Role
            };
        }
    }
}
