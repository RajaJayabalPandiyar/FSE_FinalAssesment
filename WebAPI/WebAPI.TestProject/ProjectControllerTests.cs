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
    public class ProjectControllerTests
    {
        private const string ServiceBaseURL = "http://localhost:50875/";

        [Test]
        public void GetTest()
        {
            var projectController = new ProjectController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            projectController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)projectController.Get();
            var responseResult = JsonConvert.DeserializeObject<List<ProjectModel>>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult.Any(), true);
        }

        [Test]
        public void SearchTest()
        {
            var projectController = new ProjectController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            projectController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)projectController.Search(1);
            var responseResult = JsonConvert.DeserializeObject<ProjectModel>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void PostTest()
        {
            var project = new ProjectModel()
            {
                Project_ID = 1,
                ProjectName = "Microsoft",
                Start_Date = null,
                End_Date = null,
                Priority = 1
            };

            var projectController = new ProjectController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            projectController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)projectController.Post(project);
            var responseResult = JsonConvert.DeserializeObject<bool>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(responseResult);
        }

        [Test]
        public void PutTest()
        {
            var project = new ProjectModel()
            {
                Project_ID = 1,
                ProjectName = "Bosch",
                Start_Date = null,
                End_Date = null,
                Priority = 1
            };

            var projectController = new ProjectController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            projectController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)projectController.Put(project);
            var responseResult = JsonConvert.DeserializeObject<bool>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(responseResult);
        }
    }
}
