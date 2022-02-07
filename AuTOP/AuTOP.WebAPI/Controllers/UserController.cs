using System;
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
    public class UserController : ApiController
    {
        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }
        protected IUserService UserService { get; set; }

        [Route("users")]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await UserService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // GET api/values/5
        [Route("users/{userId}")]
        public async Task<HttpResponseMessage> GetById(Guid userId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await UserService.GetById(userId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // POST api/values
        [Route("users")]
        public async Task<HttpResponseMessage> Post([FromBody] IUser user)
        {
            try
            {
                await UserService.Post(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
