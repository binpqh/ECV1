using Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IStudentService
    {
        Task<StudentTypeResult> CreateAsync(StudentTypeInput create);
        Task<StudentTypeResult> UpdateAsync(int id,StudentTypeInput update);
        Task DeleteAsync(int id);
        Task<StudentTypeResult> GetByIdAsync(int id);
        Task<List<StudentTypeResult>> GetAllAsync();

    }
}
