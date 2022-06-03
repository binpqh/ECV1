using Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IStudentPointService
    {
        Task<StudentPointTypeResult> CreateStudentPoint(StudentPointTypeInput studentPoint);
        Task<StudentPointTypeResult> UpdateStudentPoint(int id,StudentPointTypeInput studentPoint);
        Task DeleteStudentPoint(int id);
        Task<List<StudentPointTypeResult>> GetAllStudentPoint();
    }
}
