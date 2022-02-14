using AuTOP.Model;
using AuTOP.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AuTOP.WebAPI.Controllers
{
    public class MotorController : ApiController
    {

        public MotorController(IMotorService motorService)
        {
            this.MotorService = motorService;
        }
        protected IMotorService MotorService { get; set; }

        public async Task<HttpResponseMessage> GetAllAsync( )
        {
            return Request.CreateResponse(HttpStatusCode.OK, await MotorService.GetAllAsync());
        }
        public async Task<HttpResponseMessage> GetByIdAsync(Guid id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await MotorService.GetByIdAsync(id));
        }

        public async Task<HttpResponseMessage> PostAsync(Motor motor)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await MotorService.PostAsync(motor));
        }

        public async Task<HttpResponseMessage> PutAsync(Motor motor)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await MotorService.PutAsync(motor));
        }

        public async Task<HttpResponseMessage> DeleteAsync(Guid Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await MotorService.DeleteAsync(Id));
        }
    }
    
}
