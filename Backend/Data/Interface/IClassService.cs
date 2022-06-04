using Data.Defined.Enum;
using Data.Types;

namespace Data.Interface
{
    public interface IClassService
    {
        Task<List<ClassResult>> GetAllAsync();
        Task<ClassResult> GetAsync(int id);
        Task<ClassResult> CreateAsync(ClassInput create);
        Task<ClassResult> UpdateAsync(int id,ClassInput update);
        Task DeleteAsync(int id);
        Task TimeTable(int id, WeekdayEnum weekday);
        Task<List<TimeTableTypeResult>> GetTimeTable(int id);
        Task DeteleClassDay(int id, WeekdayEnum weekday);

    }
}
