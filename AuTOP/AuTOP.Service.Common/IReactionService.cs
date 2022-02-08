using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Service.Common
{
    public interface IReactionService
    {
        Task<int> GetLikes();

        Task<int> GetDislikes();
    }
}
