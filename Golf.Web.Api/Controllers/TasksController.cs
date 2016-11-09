using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Golfe.Data.Models;
using Golfe.Data.Repository.Interfaces;

namespace Golf.Web.Api.Controllers
{
    [Authorize]
    [AllowAnonymous] 
    [RoutePrefix("api/Tasks")]
    public class TaskController : ApiController
    {
        protected ITarefasRepository TaskRepository;

        public TaskController(ITarefasRepository repository)
        {
            this.TaskRepository = repository;
        }

        [HttpGet]
        [AllowAnonymous] 
        public IHttpActionResult Get()
        {
            try
            {
                var tasks = this.TaskRepository.GetTarefas();
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Accepted, tasks));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Unable to Retrieve Tasks"));
            }
                
        }

        [HttpPut]
        [AllowAnonymous] 
        public IHttpActionResult Put([FromBody] Tarefas taskToUpdate)
        {
            if (taskToUpdate == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Passed object is null"));
            }
            try
            {
                var id = taskToUpdate.Id;
                this.TaskRepository.Edit(id,taskToUpdate);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Accepted, "Update succeeded"));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Unable to update object"));
                
            }

        }

        [HttpDelete]
        [AllowAnonymous]
        public IHttpActionResult Delete(int id)
        {
          
            try
            {
                this.TaskRepository.Delete(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Accepted, "Deleted succeeded"));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Unable to delete object"));

            }

        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult CreateTask([FromBody] Tarefas taskToCreate)
        {
            if (taskToCreate == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Passed object is null"));
            }
            try
            {
                this.TaskRepository.Add(taskToCreate);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Accepted, "Added succeeded"));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Unable to add object"));

            }

        }

        
    }
}
