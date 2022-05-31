using Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IManagerService
    {
        //CRUD quản lý
        Task<ManagerTypeResult> CreateAsync(ManagerTypeInput create);
        Task<ManagerTypeResult> UpdateAsync(int id, ManagerTypeInput input);
        Task DeleteAsync(int id);
        Task<ManagerTypeResult> GetByIdAsync(int id);
        Task<List<ManagerTypeResult>> GetAllAsync();
        //Thanh toán


    }
}
