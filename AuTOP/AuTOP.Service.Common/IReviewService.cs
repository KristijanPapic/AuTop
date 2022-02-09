using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Model.Common;

namespace AuTOP.Service.Common
{
    public interface IReviewService
    {
        Task<List<IReview>> GetAsync();
        Task<IReview> GetByIdAsync(Guid reviewId);
        Task PostAsync(IReview review);
    }
}
