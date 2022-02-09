using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Model.Common;

namespace AuTOP.Repository.Common
{
    public interface IReviewRepository
    {
        Task<List<IReview>> GetAsync();
        Task<IReview> GetByIdAsync(Guid reviewId);
        Task PostAsync(IReview review);
    }
}
