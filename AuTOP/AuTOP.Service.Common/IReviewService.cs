using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Common;
using AuTOP.Model.Common;

namespace AuTOP.Service.Common
{
    public interface IReviewService
    {
        Task<List<IReview>> GetAsync(ReviewFilter filter);
        Task<IReview> GetByIdAsync(Guid reviewId);
        Task<bool> PostAsync(IReview review);
        Task<bool> PutAsync(Guid reviewId, IReview review);
        Task<bool> DeleteAsync(Guid reviewId);
    }
}
