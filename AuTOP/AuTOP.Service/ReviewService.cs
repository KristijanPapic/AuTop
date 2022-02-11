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
        public ReviewService(IReviewRepository reviewRepository, IReactionRepository reactionRepository, IUserRepository userRepository)
        {
            this.ReviewRepository = reviewRepository;
            this.UserRepository = userRepository;
            this.ReactionRepository = reactionRepository;
        }
       
        protected IReviewRepository ReviewRepository { get; set; }
        protected IUserRepository UserRepository { get; set; }
        protected IReactionRepository ReactionRepository { get; set; }
        public async Task<List<IReview>> GetAsync(ReviewFilter filter)
        {
            List<IReview> reviews = await ReviewRepository.GetAsync(filter);
            foreach (IReview review in reviews)
            {
                review.LikePercentage = await ReactionRepository.GetLikePercentage(review.UserId);
            }
            return reviews;
        }
        public async Task<IReview> GetByIdAsync(Guid reviewId)
        {
            return await ReviewRepository.GetByIdAsync(reviewId);
        }
        public async Task<bool> PutAsync(Guid reviewId, IReview review)
        {
            return await ReviewRepository.PutAsync(reviewId, review);
        }
        public async Task<bool> PostAsync(IReview review)
        {
            return await ReviewRepository.PostAsync(review);
        }

        public async Task<bool> DeleteAsync(Guid reviewId)
        {
            return await ReviewRepository.DeleteAsync(reviewId);
        }
    }
}
