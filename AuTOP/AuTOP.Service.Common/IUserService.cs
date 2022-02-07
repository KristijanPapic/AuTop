using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Model.Common;

namespace AuTOP.Service.Common
{

    public interface IUserService
    {
        Task<List<IUser>> Get();

        Task<List<IUser>> GetById(Guid userId);
        Task Post(IUser user);


    }
}
