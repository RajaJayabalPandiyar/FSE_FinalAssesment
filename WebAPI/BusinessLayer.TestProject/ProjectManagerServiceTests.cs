using Common.DataModel;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.TestProject
{
    [TestFixture]
    public class ProjectManagerServiceTests
    {
        public ProjectManagerService _projectManagerService;

        public ProjectManagerServiceTests()
        {
            _projectManagerService = new ProjectManagerService();
        }

        [Test]
        public void AddTaskForValidDataTest()
        {
            var validData = new TaskModel()
            {
                Parent_ID = 1,
                Project_ID = 2,
                TaskName = "Generate Scripts",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(1),
                Priority = 1,
                Status = true
            };
            var isSuccess = _projectManagerService.AddTask(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void AddTaskForNullTest()
        {
            var isSuccess = _projectManagerService.AddTask(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void AddUserForValidDataTest()
        {
            var validData = new UserModel()
            {
                FirstName = "Robert",
                LastName = "Anderson",
                Employee_ID = 1,
                Project_ID = 2,
                Task_ID = 12
            };
            var isSuccess = _projectManagerService.AddUser(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void AddUserForNullTest()
        {
            var isSuccess = _projectManagerService.AddUser(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void AddProjectForValidDataTest()
        {
            var validData = new ProjectModel()
            {
                ProjectName = "Microsoft",
                Start_Date = null,
                End_Date = null,
                Priority = 1
            };
            var isSuccess = _projectManagerService.AddProject(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void AddProjectForNullTest()
        {
            var isSuccess = _projectManagerService.AddProject(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void AddParentTaskForValidDataTest()
        {
            var validData = new ParentTaskModel()
            {
                ParentTaskName = "Build Framework"
            };
            var isSuccess = _projectManagerService.AddParentTask(validData);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void AddParentTaskForNullTest()
        {
            var isSuccess = _projectManagerService.AddParentTask(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void GetTasksTest()
        {
            var tasks = _projectManagerService.GetAllTasks();
            Assert.NotZero(tasks.Count);
        }

        [Test]
        public void GetUsersTest()
        {
            var tasks = _projectManagerService.GetAllUsers();
            Assert.NotZero(tasks.Count);
        }

        [Test]
        public void GetProjectsTest()
        {
            var tasks = _projectManagerService.GetAllProjects();
            Assert.NotZero(tasks.Count);
        }

        [Test]
        public void GetTaskTestForValidDataTest()
        {
            var task = _projectManagerService.GetTaskByID(1);
            Assert.IsNotNull(task);
        }



        [Test]
        public void GetUserTestForValidDataTest()
        {
            var task = _projectManagerService.GetUserByID(1);
            Assert.IsNotNull(task);
        }


        [Test]
        public void GetProjectTestForValidDataTest()
        {
            var task = _projectManagerService.GetProjectByID(1);
            Assert.IsNotNull(task);
        }



        [Test]
        public void SearchUsersForValidDataTest()
        {
            var users = _projectManagerService.SearchUsers("Robert", "FirstName");
            Assert.NotZero(users.Count);
        }



        [Test]
        public void SearchUsersForNullTest()
        {
            var users = _projectManagerService.SearchUsers(null, null);
            Assert.Zero(users.Count);
        }

        [Test]
        public void SearchProjectsForValidDataTest()
        {
            var projects = _projectManagerService.SearchProjects("Microsoft", "StartDate");
            Assert.NotZero(projects.Count);
        }

        [Test]
        public void SearchProjectsForNullTest()
        {
            var projects = _projectManagerService.SearchProjects(null, null);
            Assert.Zero(projects.Count);
        }

        [Test]
        public void UpdateTaskForValidDataTest()
        {
            var validData = new TaskModel()
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
            var isSuccess = _projectManagerService.UpdateTask(validData);
            Assert.AreEqual(true, isSuccess);
        }



        [Test]
        public void UpdateTaskForNullTest()
        {
            var isSuccess = _projectManagerService.UpdateTask(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void UpdateUserForValidDataTest()
        {
            var validData = new UserModel()
            {
                User_ID = 1,
                FirstName = "Robert",
                LastName = "Anderson",
                Employee_ID = 1,
                Project_ID = 1,
                Task_ID = 1
            };
            var isSuccess = _projectManagerService.UpdateUser(validData);
            Assert.AreEqual(true, isSuccess);
        }


        [Test]
        public void UpdateUserForNullTest()
        {
            var isSuccess = _projectManagerService.UpdateUser(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void UpdateProjectForValidDataTest()
        {
            var validData = new ProjectModel()
            {
                Project_ID = 1,
                ProjectName = "Microsoft",
                Start_Date = null,
                End_Date = null,
                Priority = 1
            };
            var isSuccess = _projectManagerService.UpdateProject(validData);
            Assert.AreEqual(true, isSuccess);
        }


        [Test]
        public void UpdateProjectForNullTest()
        {
            var isSuccess = _projectManagerService.UpdateProject(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void UpdateParentTaskForValidDataTest()
        {
            var validData = new ParentTaskModel()
            {
                Parent_ID = 1,
                ParentTaskName = "Build Framework"
            };
            var isSuccess = _projectManagerService.UpdateParentTask(validData);
            Assert.AreEqual(true, isSuccess);
        }



        [Test]
        public void UpdateParentTaskForNullTest()
        {
            var isSuccess = _projectManagerService.UpdateParentTask(null);
            Assert.AreEqual(false, isSuccess);
        }

        [Test]
        public void DeleteUserTest()
        {
            var isSuccess = _projectManagerService.DeleteUser(1);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void DeleteProjectTest()
        {
            var isSuccess = _projectManagerService.DeleteProject(1);
            Assert.AreEqual(true, isSuccess);
        }

        [Test]
        public void TranslateTest_TaskToTaskModel()
        {
            EntityMapper<TaskModel, Task> mapObj = new EntityMapper<TaskModel, Task>();
            var taskModel = new TaskModel()
            {
                Parent_ID = 1,
                Project_ID = 2,
                TaskName = "Generate Scripts",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(1),
                Priority = 1,
                Status = true
            };
            var task = mapObj.Translate(taskModel);
            Assert.IsNotNull(task);
        }
    }
}
