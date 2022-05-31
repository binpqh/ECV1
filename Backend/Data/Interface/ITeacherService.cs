using Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ITeacherService
    {
        Task<TeacherTypeResult> CreateAsync(TeacherTypeInput create);
        Task<TeacherTypeResult> UpdateAsync(int id, TeacherTypeInput update);
        Task DeleteAsync(int id);
        Task<TeacherTypeResult> GetByIdAsync(int id);
        Task<List<TeacherTypeResult>> GetAllAsync();
    }
}
