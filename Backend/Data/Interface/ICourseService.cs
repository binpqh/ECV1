using Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ICourseService
    {
        Task<CourseResult> CreateAsync(CourseInput create);
        Task<CourseResult> UpdateAsync(int id, CourseInput update);
        Task DeleteAsync(int id);
        Task<List<CourseResult>> GetAllAsync();
        Task<CourseResult> GetbyIdAsync(int id);
    }
}
