using BusinessLayer;
using Common.DataModel;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagerWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/project")]
    public class ProjectController : BaseAPIController
    {
        [Route("get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return tryCatchWebMethod(() =>
            {
                var projects = new ProjectManagerService().GetAllProjects();

                return Json(projects);
            });
        }

        [Route("getProjects")]
        [HttpGet]
        public IHttpActionResult GetProjects()
        {
            return tryCatchWebMethod(() =>
            {
                var projects = new ProjectManagerService().GetAllProjects();

                var projectList = new List<object>();
                foreach (var project in projects)
                {
                    projectList.Add(new { id = project.Project_ID, text = project.ProjectName });
                }

                return Json(projectList);
            });
        }

        [Route("search/{projectID}")]
        [HttpGet]
        public IHttpActionResult Search(int projectID)
        {
            return tryCatchWebMethod(() =>
            {
                var project = new ProjectManagerService().GetProjectByID(projectID);

                return Json(project);
            });
        }

        [Route("searchProjects/{searchKeyWord}/{sortBy}")]
        [HttpGet]
        public IHttpActionResult SearchProjects(string searchKeyWord, string sortBy)
        {
            return tryCatchWebMethod(() =>
            {
                var project = new ProjectManagerService().SearchProjects(searchKeyWord, sortBy);

                return Json(project);
            });
        }

        [Route("delete/{projectID}")]
        [HttpDelete]
        public IHttpActionResult Delete(int projectID)
        {
            return tryCatchWebMethod(() =>
            {
                var isSuccess = new ProjectManagerService().DeleteProject(projectID);

                return Json(isSuccess);
            });
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ProjectModel projectModel)
        {
            return tryCatchWebMethod(() =>
            {
                var isSuccess = new ProjectManagerService().AddProject(projectModel);

                return Json(isSuccess);
            });
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Put([FromBody]ProjectModel projectModel)
        {
            return tryCatchWebMethod(() =>
            {
                var isSuccess = new ProjectManagerService().UpdateProject(projectModel);

                return Json(isSuccess);
            });
        }


    }

}
