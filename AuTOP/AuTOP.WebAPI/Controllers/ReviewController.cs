using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AuTOP.Common;
using AuTOP.Model;
using AuTOP.Model.Common;
using AuTOP.Service;
using AuTOP.Service.Common;
using AuTOP.WebAPI.Models.ViewModels;

namespace AuTOP.WebAPI.Controllers
{
    public class ReviewController : ApiController
    {
        public ReviewController(IReviewService reviewService)
        {
            this.ReviewService = reviewService;
        }
        protected IReviewService ReviewService { get; set; }

        [Route("reviews")]
        public async Task<HttpResponseMessage> GetAsync([FromUri] ReviewFilter filter, [FromUri] Sorting sort, [FromUri] Paging paging)
        {
            var reviews = await ReviewService.GetAsync(filter, sort, paging);
            if (reviews != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, reviews);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("reviews/{reviewId}")]
        public async Task<HttpResponseMessage> GetByIdAsync(Guid reviewId)
        {
            var review = await ReviewService.GetByIdAsync(reviewId);

            if(review != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, review);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        [Authorize]
        [Route("reviews")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] Review review)
        {
            IReview reviewPost = review;

            if(await ReviewService.PostAsync(reviewPost))
            {                
                return Request.CreateResponse(HttpStatusCode.OK, "New review created");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Authorize]
        [Route("reviews/{id}")]
        public async Task<HttpResponseMessage> Put(Guid id, [FromBody] Review review)
        {
            IReview reviewPut = review;
            
            if(await ReviewService.PutAsync(id, reviewPut))
            {                
                return Request.CreateResponse(HttpStatusCode.OK, "Review updated");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [Authorize]
        [Route("reviews/{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            if(await ReviewService.DeleteAsync(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Review deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Review with Id:{id} not found");
            }
        }
    }
}
