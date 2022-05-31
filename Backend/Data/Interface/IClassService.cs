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

    }
}
