﻿using AuTOP.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AuTOP.WebAPI.Controllers
{
    public class ReactionController : ApiController
    {
        public ReactionController(IReactionService reactionService)
        {
            this.ReactionService = reactionService;
        }
        protected IReactionService ReactionService { get; set; }

        public ReactionController() { }

        public async Task<HttpResponseMessage> GetLikes()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await ReactionService.GetLikes());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
            
        }

        public async Task<HttpResponseMessage> GetDislikes()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await ReactionService.GetDislikes());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
           
        }
    }
}