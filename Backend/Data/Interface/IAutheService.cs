using Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IAutheService
    {
        Task<AuthTypeResult> Login (AuthTypeInput input);
        Task<string> GetMe(int id);
        Task ChangePasswod(int id, ChangePassword req);
    }
}