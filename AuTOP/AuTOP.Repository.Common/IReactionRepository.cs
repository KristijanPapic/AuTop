using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Repository.Common
{
    public interface IReactionRepository
    {
       Task<int> GetLikes();

       Task<int> GetDislikes();
    }
}
