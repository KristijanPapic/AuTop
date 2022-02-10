using AuTOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Repository.Common
{
    public interface IReactionRepository
    {
        Task<Reaction> GetUserReaction(Guid userId, Guid reviewId);

        Task<double> GetLikes();

        Task<bool> PostAsync(Reaction reaction);

        Task<bool> PutAsync(Reaction reaction);
        
        Task<bool> DeleteAsync(Guid userId, Guid reviewId);

        
       
    }
}
