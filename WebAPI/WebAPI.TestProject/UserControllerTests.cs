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
    public class UserControllerTests
    {
        private const string ServiceBaseURL = "http://localhost:50875/";

        [Test]
        public void GetTest()
        {
            var userController = new UserController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)userController.Get();
            var responseResult = JsonConvert.DeserializeObject<List<UserModel>>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult.Any(), true);
        }

        [Test]
        public void SearchTest()
        {
            var userController = new UserController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)userController.Search(1);
            var responseResult = JsonConvert.DeserializeObject<UserModel>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);           
        }

        [Test]
        public void SearchUsersTest()
        {
            var userController = new UserController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)userController.SearchUsers("Robert", "FirstName");
            var responseResult = JsonConvert.DeserializeObject<List<List<UserModel>>>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult.Any(), true);
        }

        [Test]
        public void PostTest()
        {
            var user = new UserModel()
            {
                User_ID = 1,
                FirstName = "Robert",
                LastName = "Anderson",
                Employee_ID = 1,
                Project_ID = 1,
                Task_ID = 1
            };

            var userController = new UserController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)userController.Post(user);
            var responseResult = JsonConvert.DeserializeObject<bool>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(responseResult);
        }

        [Test]
        public void PutTest()
        {
            var user = new UserModel()
            {
                User_ID = 1,
                FirstName = "Robert",
                LastName = "Anderson",
                Employee_ID = 2,
                Project_ID = 1,
                Task_ID = 1
            };

            var userController = new UserController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)userController.Put(user);
            var responseResult = JsonConvert.DeserializeObject<bool>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(responseResult);
        }

        [Test]
        public void DeleteTest()
        {
            var userController = new UserController()
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(ServiceBaseURL)
                }
            };
            userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var httpActionResult = (HttpResponseMessage)userController.Delete(1);
            var responseResult = JsonConvert.DeserializeObject<bool>(httpActionResult.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(httpActionResult.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(responseResult);
        }
    }
}
