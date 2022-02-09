﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
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
        public async Task<HttpResponseMessage> GetAsync()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await ReviewService.GetAsync());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [Route("reviews/{reviewId}")]
        public async Task<HttpResponseMessage> GetByIdAsync(Guid reviewId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await ReviewService.GetByIdAsync(reviewId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [Route("reviews")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] Review review)
        {
            try
            {
                IReview reviewPost = review;
                await ReviewService.PostAsync(reviewPost);
                return Request.CreateResponse(HttpStatusCode.OK, "New review created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        //[Route("reviews/{id}")]
        //public async Task<HttpResponseMessage> Put(Guid id, [FromBody] User user)
        //{
        //    try
        //    {
        //        IUser userPut = user;
        //        await UserService.PutAsync(id, userPut);
        //        return Request.CreateResponse(HttpStatusCode.OK, "User updated");
        //    }
        //    catch
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}

        //// DELETE api/values/5
        //[Route("reviews/{id}")]
        //public async Task<HttpResponseMessage> Delete(Guid id)
        //{
        //    try
        //    {
        //        await UserService.DeleteAsync(id);
        //        return Request.CreateResponse(HttpStatusCode.OK, "User deleted");
        //    }
        //    catch
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, $"User with Id:{id} not found");
        //    }
        //}
    }
}
