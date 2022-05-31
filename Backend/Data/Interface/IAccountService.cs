using Data.Defined.Enum;
using Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IAccountService
    {
        Task<AccountTypeResult> RegisterStudent(AccountTypeInput regis_student,StudentTypeInput student);
        Task<AccountTypeResult> RegisterTeacher(AccountTypeInput regis_teacher,TeacherTypeInput teacher);
        Task<AccountTypeResult> RegisterMananger(AccountTypeInput regis_manager,ManagerTypeInput manager);
    }
}
