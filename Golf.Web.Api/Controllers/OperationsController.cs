using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Golfe.Data.Repository.Interfaces;

namespace Golf.Web.Api.Controllers
{
    [AllowAnonymous] 
    [RoutePrefix("api/operations")]
    public class OperationsController : ApiController
    {
        protected IOperacaoRepository OperationsRepository;

        public OperationsController(IOperacaoRepository repository)
        {
            this.OperationsRepository = repository;
        }

        [HttpGet]
        [AllowAnonymous] 
        [Route("get")]
        public IHttpActionResult GetAllOperations()
        {
            try
            {
                var tasks = this.OperationsRepository.GetOperacoes();
                return Json(tasks);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Unable to Retrieve Operations"));
            }
        }

    }
}
