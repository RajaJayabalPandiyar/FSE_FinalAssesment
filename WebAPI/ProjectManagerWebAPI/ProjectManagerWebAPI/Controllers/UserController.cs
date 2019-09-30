using BusinessLayer;
using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagerWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/user")]
    public class UserController : BaseAPIController
    {       
        [Route("get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return tryCatchWebMethod(() =>
            {
                var users = new ProjectManagerService().GetAllUsers();              

                return Json(users);
            });
        }

        [Route("getUsers")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            return tryCatchWebMethod(() =>
            {
                var users = new ProjectManagerService().GetAllUsers();
                var userList = new List<object>();
                foreach(var user in users)
                {
                    userList.Add(new { id = user.User_ID, text = user.FirstName + " " + user.LastName });
                }

                return Json(userList);
            });
        }

        [Route("search/{userID}")]
        [HttpGet]
        public IHttpActionResult Search(int userID)
        {
            return tryCatchWebMethod(() =>
            {
                var user = new ProjectManagerService().GetUserByID(userID);

                return Json(user);
            });
        }

        [Route("searchUsers/{searchKeyWord}/{sortBy}")]
        [HttpGet]
        public IHttpActionResult SearchUsers(string searchKeyWord, string sortBy)
        {
            return tryCatchWebMethod(() =>
            {
                var users = new ProjectManagerService().SearchUsers(searchKeyWord, sortBy);

                return Json(users);
            });
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]UserModel userModel)
        {
            return tryCatchWebMethod(() =>
            {
                var isSuccess = new ProjectManagerService().AddUser(userModel);
                
                return Json(isSuccess);
            });
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Put([FromBody]UserModel userModel)
        {
            return tryCatchWebMethod(() =>
            {
                var isSuccess = new ProjectManagerService().UpdateUser(userModel);
                
                return Json(isSuccess);
            });
        }

        [Route("delete/{userID}")]
        [HttpDelete]
        public IHttpActionResult Delete(int userID)
        {
            return tryCatchWebMethod(() =>
            {
                var isSuccess = new ProjectManagerService().DeleteUser(userID);
                
                return Json(isSuccess);
            });
        }
    }
}
