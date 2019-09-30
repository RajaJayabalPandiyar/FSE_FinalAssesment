using Common.DataModel;
using BusinessLayer;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagerWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/task")]
    public class TaskController : BaseAPIController
    {
        [Route("get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return tryCatchWebMethod(() =>
            {
                var tasks = new ProjectManagerService().GetAllTasks();
                
                return Json(tasks);
            });
        }

        [Route("getParentTasks")]
        [HttpGet]
        public IHttpActionResult GetParentTasks()
        {
            return tryCatchWebMethod(() =>
            {
                var parentTasks = new ProjectManagerService().GetAllParentTasks();
                var parentTaskList = new List<object>();
                foreach (var parentTask in parentTasks)
                {
                    parentTaskList.Add(new { id = parentTask.Parent_ID, text = parentTask.ParentTaskName });
                }

                return Json(parentTaskList);
            });
        }

        [Route("search/{taskID}")]
        [HttpGet]
        public IHttpActionResult Search(int taskID)
        {
            return tryCatchWebMethod(() =>
            {
                var task = new ProjectManagerService().GetTaskByID(taskID);

                return Json(task);
            });
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]TaskModel taskModel)
        {
            return tryCatchWebMethod(() =>
            {
                var isSuccess = false;
                if (taskModel.SetAsParent)
                {
                    var parentTaskModel = new ParentTaskModel() { ParentTaskName = taskModel.TaskName };
                    isSuccess = new ProjectManagerService().AddParentTask(parentTaskModel);
                }
                else
                {
                    isSuccess = new ProjectManagerService().AddTask(taskModel);
                }

                return Json(isSuccess);
            });
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Put([FromBody]TaskModel taskModel)
        {
            return tryCatchWebMethod(() =>
            {
                var isSuccess = new ProjectManagerService().UpdateTask(taskModel);
                
                return Json(isSuccess);
            });
        }        
    }
}
