using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AuTOP.Service;
using AuTOP.Service.Common;

namespace AuTOP.WebAPI.Controllers
{
    public class ManufacturerController :ApiController
    {
        private IManufacturerServis manufacturerServis;

        public ManufacturerController(IManufacturerServis manufacturerServis)
        {
            this.manufacturerServis = manufacturerServis;
        }
        public async Task<HttpResponseMessage> GetAllManufacturers(string search = "", string sortBy = "Name", string sortMethod = "", int page = 1)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
  
        }
        public async Task<HttpResponseMessage> GetManufacturer([FromUri] Guid id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}