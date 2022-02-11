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
        public async Task<HttpResponseMessage> GetAsync(Guid? searchOpt = null, string searchBy = "ModelVersionId")
        {
            Guid search;
            if (searchOpt.HasValue)
            {
                search = searchOpt.Value;
            }
            else
            {
                search = Guid.Empty;
            }
            ReviewFilter filter = new ReviewFilter(searchBy, search);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await ReviewService.GetAsync(filter));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
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
            var status = await ReviewService.PostAsync(reviewPost);

            if(status)
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
            var status = await ReviewService.PutAsync(id, reviewPut);
            
            if(status)
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
            var status = await ReviewService.DeleteAsync(id);

            if(status)
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
