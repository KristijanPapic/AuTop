using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Common;
using AuTOP.Model.Common;
using AuTOP.Repository;
using AuTOP.Repository.Common;
using AuTOP.Service.Common;

namespace AuTOP.Service
{
    public class ReviewService : IReviewService
    {
        public ReviewService(IReviewRepository reviewRepository)
        {
            this.ReviewRepository = reviewRepository;
        }
        protected IReviewRepository ReviewRepository { get; set; }
        public async Task<List<IReview>> GetAsync(ReviewFilter filter)
        {
            return await ReviewRepository.GetAsync(filter);
        }
        public async Task<IReview> GetByIdAsync(Guid reviewId)
        {
            return await ReviewRepository.GetByIdAsync(reviewId);
        }
        public async Task PostAsync(IReview review)
        {
            await ReviewRepository.PostAsync(review);
        }
        public async Task DeleteAsync(Guid reviewId)
        {
            await ReviewRepository.DeleteAsync(reviewId);
        }
    }
}
