using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Golfe.Data.Repository.Interfaces;

namespace Golf.Web.Api.Controllers
{
    [AllowAnonymous] 
    [RoutePrefix("api/gameAreas")]
    public class GameAreasController : ApiController
    {
        protected IAreaJogoRepository GameAreasRepository;

        public GameAreasController(IAreaJogoRepository repository)
        {
            this.GameAreasRepository = repository;
        }

        [HttpGet]
        [AllowAnonymous] 
        [Route("get")]
        public IHttpActionResult GetAllAreas()
        {
            try
            {
                var tasks = this.GameAreasRepository.GetAreasJogo();
                return Json(tasks);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Unable to Retrieve Areas"));
            }
        }

    }
}
