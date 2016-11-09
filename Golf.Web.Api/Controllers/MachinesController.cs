using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Golfe.Data.Repository.Interfaces;

namespace Golf.Web.Api.Controllers
{
    [AllowAnonymous] 
    [RoutePrefix("api/machines")]
    public class MachinesController : ApiController
    {
        protected IMaquinasRepository MachinesRepository;

        public MachinesController(IMaquinasRepository repository)
        {
            this.MachinesRepository = repository;
        }

        [HttpGet]
        [AllowAnonymous] 
        [Route("get")]
        public IHttpActionResult GetAllAreas()
        {
            try
            {
                var tasks = this.MachinesRepository.GetMaquinas();
                return Json(tasks);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Unable to Retrieve Machines"));
            }
            
        }

    }
}
