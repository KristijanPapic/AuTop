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
    [Authorize]
    public class UserController : ApiController
    {
        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }
        protected IUserService UserService { get; set; }

        [Route("users")]
        public async Task<HttpResponseMessage> GetAsync(string searchQuery = "Username", string sortBy = "Username", string sortMethod = "ASC", int page = 1)
        {
            UserFilter filter = new UserFilter(searchQuery);
            Sorting sorting = new Sorting(sortBy, sortMethod);
            Paging paging = new Paging(page);

            var users = await UserService.GetAsync(filter, sorting, paging);

            if (users != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("users/{userId}")]
        public async Task<HttpResponseMessage> GetByIdAsync(Guid userId)
        {
            var user = await UserService.GetByIdAsync(userId);

            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("users")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] User user)
        {
            IUser userPost = user;
            var status = await UserService.PostAsync(userPost);

            if (status)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "New user created");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("users/{id}")]
        public async Task<HttpResponseMessage> Put(Guid id, [FromBody] User user)
        {
            IUser userPut = user;
            var status = await UserService.PutAsync(id, userPut);

            if(status)
            {                
                return Request.CreateResponse(HttpStatusCode.OK, "User updated");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("users/{id}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {

            var status = await UserService.DeleteAsync(id);
            if (status)
            {                
                return Request.CreateResponse(HttpStatusCode.OK, "User deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"User with Id:{id} not found");
            }
        }
    }
}
