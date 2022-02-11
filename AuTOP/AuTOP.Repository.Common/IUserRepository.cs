using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Common;
using AuTOP.Model.Common;

namespace AuTOP.Repository.Common
{
    public interface IUserRepository
    {
        Task<List<IUser>> GetAsync(UserFilter filter, Sorting sort, Paging paging);
        Task<IUser> GetByIdAsync(Guid userId);
        Task<bool> PostAsync(IUser user);
        Task<bool> PutAsync(Guid userId, IUser user);
        Task<bool> DeleteAsync(Guid userId);
        Task<Guid> GetIdbyName(string name);
    }
}
