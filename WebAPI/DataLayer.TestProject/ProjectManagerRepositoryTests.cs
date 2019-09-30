using NUnit.Framework;
using System;
using System.Linq;

namespace DataLayer.Tests
{
    public class ProjectManagerRepositoryTests
    {
        [Test]
        public void InsertTaskForValidDataTest()
        {
            var validData = new Task()
            {
                Parent_ID = 1,
                Project_ID = 1,
                TaskName = "Generate Scripts",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(1),
                Priority = 1,
                Status = true
            };
            var isSuccess = DataLayer.InsertTask(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void InsertTaskForNullTest()
        {
            var isSuccess = DataLayer.InsertTask(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void InsertUserForValidDataTest()
        {
            var validData = new User()
            {
                FirstName = "Robert",
                LastName = "Anderson",
                Employee_ID = 1,
                Project_ID = 1,
                Task_ID = 1
            };
            var isSuccess = DataLayer.InsertUser(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void InsertUserForNullTest()
        {
            var isSuccess = DataLayer.InsertUser(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void InsertProjectForValidDataTest()
        {
            var validData = new Project()
            {
                ProjectName = "Microsoft",
                Start_Date = null,
                End_Date = null,
                Priority = 1
            };
            var isSuccess = DataLayer.InsertProject(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void InsertProjectForNullTest()
        {
            var isSuccess = DataLayer.InsertProject(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void InsertParentTaskForValidDataTest()
        {
            var validData = new ParentTask()
            {
                ParentTaskName = "Build Framework"
            };
            var isSuccess = DataLayer.InsertParentTask(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void InsertParentTaskForNullTest()
        {
            var isSuccess = DataLayer.InsertParentTask(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void GetTasksTest()
        {
            var tasks = DataLayer.GetTasks();
            Assert.NotZero(tasks.Count);
        }

        [Test]
        public void GetUsersTest()
        {
            var tasks = DataLayer.GetUsers();
            Assert.NotZero(tasks.Count);
        }

        [Test]
        public void GetProjectsTest()
        {
            var tasks = DataLayer.GetProjects();
            Assert.NotZero(tasks.Count);
        }

        [Test]
        public void GetTaskTestForValidDataTest()
        {
            var task = DataLayer.GetTask(1);
            Assert.IsNotNull(task);
        }

        [Test]
        public void GetUserTestForValidDataTest()
        {
            var task = DataLayer.GetUser(1);
            Assert.IsNotNull(task);
        }

        [Test]
        public void GetProjectTestForValidDataTest()
        {
            var task = DataLayer.GetProject(1);
            Assert.IsNotNull(task);
        }

        [Test]
        public void SearchUsersForValidDataTest()
        {
            var users = DataLayer.SearchUsers("Robert", "FirstName");
            Assert.NotZero(users.Count);
        }

        [Test]
        public void SearchUsersForNullTest()
        {
            var users = DataLayer.SearchUsers(null, null);
            Assert.Zero(users.Count);
        }

        [Test]
        public void SearchProjectsForValidDataTest()
        {
            var projects = DataLayer.SearchProjects("Microsoft", "StartDate");
            Assert.NotZero(projects.Count);
        }

        [Test]
        public void SearchProjectsForNullTest()
        {
            var projects = DataLayer.SearchProjects(null, null);
            Assert.Zero(projects.Count);
        }

        [Test]
        public void UpdateTaskForValidDataTest()
        {
            var validData = new Task()
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
            var isSuccess = DataLayer.UpdateTask(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void UpdateTaskForNullTest()
        {
            var isSuccess = DataLayer.UpdateTask(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void UpdateUserForValidDataTest()
        {
            var validData = new User()
            {
                User_ID = 1,
                FirstName = "Robert",
                LastName = "Anderson",
                Employee_ID = 1,
                Project_ID = 1,
                Task_ID = 1
            };
            var isSuccess = DataLayer.UpdateUser(validData);
            Assert.AreEqual(true, isSuccess);
        }
        
        [Test]
        public void UpdateUserForNullTest()
        {
            var isSuccess = DataLayer.UpdateUser(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void UpdateProjectForValidDataTest()
        {
            var validData = new Project()
            {
                Project_ID = 1,
                ProjectName = "Microsoft",
                Start_Date = null,
                End_Date = null,
                Priority = 1
            };
            var isSuccess = DataLayer.UpdateProject(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void UpdateProjectForNullTest()
        {
            var isSuccess = DataLayer.UpdateProject(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void UpdateParentTaskForValidDataTest()
        {
            var validData = new ParentTask()
            {
                Parent_ID = 1,
                ParentTaskName = "Build Framework"
            };
            var isSuccess = DataLayer.UpdateParentTask(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void UpdateParentTaskForNullTest()
        {
            var isSuccess = DataLayer.UpdateParentTask(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void DeleteUserTest()
        {
            var isSuccess = DataLayer.DeleteUser(1);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void DeleteProjectTest()
        {
            var isSuccess = DataLayer.DeleteProject(1);
            Assert.AreEqual(true, isSuccess);
        }
    }
}
