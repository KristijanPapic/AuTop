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
        public ReviewService(IReactionRepository reactionRepository)
        {
            this.ReactionRepository = reactionRepository;
        }
        protected IReviewRepository ReviewRepository { get; set; }
        protected IReactionRepository ReactionRepository { get; set; }
        public async Task<List<IReview>> GetAsync(ReviewFilter filter)
        {
            List<IReview> reviews = await ReviewRepository.GetAsync(filter);
            foreach (IReview review in reviews)
            {
                review.LikePercentage = ReactionRepository.GetLikes();
            }
            return reviews;
        }
        public async Task<IReview> GetByIdAsync(Guid reviewId)
        {
            return await ReviewRepository.GetByIdAsync(reviewId);
        }
        public async Task PutAsync(Guid reviewId, IReview review)
        {
            await ReviewRepository.PutAsync(reviewId, review);
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
