using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Golfe.Data.Repository.Interfaces;

namespace Golf.Web.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/functionaries")]
    public class FunctionariesController : ApiController
    {
        protected IFuncionariosRepository FunctionariesRepository;

        public FunctionariesController(IFuncionariosRepository repository)
        {
            this.FunctionariesRepository = repository;
        }

        [HttpGet]
        [AllowAnonymous] 
        [Route("get")]
        public IHttpActionResult GetAllFunctionaries()
        {
            try
            {
                var tasks = this.FunctionariesRepository.GetFuncionarios();
                return Json(tasks);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Unable to Retrieve Functionaries"));
            }
        }

    }
}
