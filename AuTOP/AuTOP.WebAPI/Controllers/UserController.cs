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
        public async Task<HttpResponseMessage> GetAsync()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await UserService.GetAsync());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // GET api/values/5
        [Route("users/{userId}")]
        public async Task<HttpResponseMessage> GetByIdAsync(Guid userId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await UserService.GetByIdAsync(userId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // POST api/values
        [Route("users")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] User user)
        {
            try
            {
                IUser userPost = user;
                await UserService.PostAsync(userPost);
                return Request.CreateResponse(HttpStatusCode.OK, "New user created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        // PUT api/values/5
        [Route("users/{id}")]
        public async Task<HttpResponseMessage> Put(Guid id, [FromBody] User user)
        {
            try
            {
                IUser userPut = user;
                await UserService.PutAsync(id, userPut);
                return Request.CreateResponse(HttpStatusCode.OK, "User updated");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/values/5
        [Route("users/{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                await UserService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, "User deleted");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"User with Id:{id} not found");
            }
        }
    }
}
