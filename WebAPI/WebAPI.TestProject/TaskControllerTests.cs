using System;
using NUnit.Framework;
using System.Net.Http;
using ProjectManagerWebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Hosting;
using Common.DataModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.Linq;

namespace ProjectManagerController.Tests
{
    [TestFixture]
    public class TaskControllerTests
    {
        private const string ServiceBaseURL = "http://localhost:50875/";

        [Test]
        public void GetTest()
        {
            var taskController = new TaskController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            taskController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)taskController.Get();
            var responseResult = JsonConvert.DeserializeObject<List<TaskModel>>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult.Any(), true);
        }

        [Test]
        public void SearchTest()
        {
            var taskController = new TaskController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            taskController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)taskController.Search(1);
            var responseResult = JsonConvert.DeserializeObject<TaskModel>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);           
        }
        
        [Test]
        public void PostTest()
        {
            var task = new TaskModel()
            {
                Task_ID = 1,
                TaskName = "Generate Scripts",
                Parent_ID = 1,
                Project_ID = 1,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(1),
                Priority = 1,
                Status = true
            };

            var taskController = new TaskController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            taskController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)taskController.Post(task);
            var responseResult = JsonConvert.DeserializeObject<bool>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(responseResult);
        }

        [Test]
        public void PutTest()
        {
            var task = new TaskModel()
            {
                Task_ID = 1,
                TaskName = "Deploy",
                Parent_ID = 1,
                Project_ID = 1,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(1),
                Priority = 1,
                Status = true
            };

            var taskController = new TaskController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            taskController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)taskController.Put(task);
            var responseResult = JsonConvert.DeserializeObject<bool>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(responseResult);
        }        
    }
}
