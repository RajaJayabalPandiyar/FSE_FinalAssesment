using DataLayer;
using Common.DataModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLayer
{
    public class ProjectManagerService
    {
        public List<TaskModel> GetAllTasks()
        {
            EntityMapper<Task, TaskModel> mapObj = new EntityMapper<Task, TaskModel>();
            List<Task> taskList = DataLayer.DataLayer.GetTasks();
            List<TaskModel> taskModels = new List<TaskModel>();
            foreach (var task in taskList)
            {
                var taskModel = mapObj.Translate(task);
                taskModel.ParentTaskName = DataLayer.DataLayer.GetParentTask(task.Parent_ID).ParentTaskName;
                taskModels.Add(taskModel);
            }

            return taskModels;
        }

        public List<UserModel> GetAllUsers()
        {
            EntityMapper<User, UserModel> mapObj = new EntityMapper<User, UserModel>();
            List<User> userList = DataLayer.DataLayer.GetUsers();
            List<UserModel> userModels = new List<UserModel>();
            foreach (var user in userList)
            {
                userModels.Add(mapObj.Translate(user));
            }

            return userModels;
        }

        public List<ProjectModel> GetAllProjects()
        {
            EntityMapper<Project, ProjectModel> mapObj = new EntityMapper<Project, ProjectModel>();
            List<Project> projectList = DataLayer.DataLayer.GetProjects();
            List<ProjectModel> projectModels = new List<ProjectModel>();
            foreach (var project in projectList)
            {
                var projectModel = mapObj.Translate(project);
                projectModel.NoOfTasks = DataLayer.DataLayer.GetTasks()
                    .Where(x => x.Project_ID == projectModel.Project_ID).ToList().Count;
                projectModel.CompletedTasks = DataLayer.DataLayer.GetTasks()
                    .Where(x => x.Project_ID == projectModel.Project_ID && x.End_Date.Date <= DateTime.Now.Date).ToList().Count;
                projectModels.Add(projectModel);
            }

            return projectModels;
        }

        public List<ParentTaskModel> GetAllParentTasks()
        {
            EntityMapper<ParentTask, ParentTaskModel> mapObj = new EntityMapper<ParentTask, ParentTaskModel>();
            List<ParentTask> parentTaskList = DataLayer.DataLayer.GetParentTasks();
            List<ParentTaskModel> parentTaskModels = new List<ParentTaskModel>();
            foreach (var parent in parentTaskList)
            {
                var parentTaskModel = mapObj.Translate(parent);
                parentTaskModels.Add(parentTaskModel);
            }

            return parentTaskModels;
        }

        public UserModel GetUserByID(int userID)
        {
            EntityMapper<User, UserModel> mapObj = new EntityMapper<User, UserModel>();
            User user = DataLayer.DataLayer.GetUser(userID);
            UserModel userModel = new UserModel();
            userModel = mapObj.Translate(user);

            return userModel;
        }

        public ProjectModel GetProjectByID(int projectID)
        {
            EntityMapper<Project, ProjectModel> mapObj = new EntityMapper<Project, ProjectModel>();
            Project project = DataLayer.DataLayer.GetProject(projectID);
            ProjectModel projectModel = new ProjectModel();
            projectModel = mapObj.Translate(project);

            return projectModel;
        }

        public TaskModel GetTaskByID(int taskID)
        {
            EntityMapper<Task, TaskModel> mapObj = new EntityMapper<Task, TaskModel>();
            Task task = DataLayer.DataLayer.GetTask(taskID);
            TaskModel taskModel = new TaskModel();
            taskModel = mapObj.Translate(task);

            return taskModel;
        }

        public ParentTaskModel GetParentTaskByID(int parentID)
        {
            EntityMapper<ParentTask, ParentTaskModel> mapObj = new EntityMapper<ParentTask, ParentTaskModel>();
            ParentTask parentTask = DataLayer.DataLayer.GetParentTask(parentID);
            ParentTaskModel parentTaskModel = new ParentTaskModel();
            parentTaskModel = mapObj.Translate(parentTask);

            return parentTaskModel;
        }

        public bool AddTask(TaskModel taskModel)
        {
            EntityMapper<TaskModel, Task> mapObj = new EntityMapper<TaskModel, Task>();
            var task = mapObj.Translate(taskModel);
            return DataLayer.DataLayer.InsertTask(task);
        }

        public bool AddProject(ProjectModel projectModel)
        {
            EntityMapper<ProjectModel, Project> mapObj = new EntityMapper<ProjectModel, Project>();
            var project = mapObj.Translate(projectModel);
            if(project.Start_Date == default(DateTime))
            {
                project.Start_Date = null;
            }
            if (project.End_Date == default(DateTime))
            {
                project.End_Date = null;
            }
            return DataLayer.DataLayer.InsertProject(project);
        }

        public bool AddUser(UserModel userModel)
        {
            EntityMapper<UserModel, User> mapObj = new EntityMapper<UserModel, User>();
            var user = mapObj.Translate(userModel);
            return DataLayer.DataLayer.InsertUser(user);
        }

        public bool AddParentTask(ParentTaskModel parentTaskModel)
        {
            EntityMapper<ParentTaskModel, ParentTask> mapObj = new EntityMapper<ParentTaskModel, ParentTask>();
            var parentTask = mapObj.Translate(parentTaskModel);
            return DataLayer.DataLayer.InsertParentTask(parentTask);
        }      

        public bool UpdateUser(UserModel userModel)
        {
            EntityMapper<UserModel, User> mapObj = new EntityMapper<UserModel, User>();
            var user = mapObj.Translate(userModel);
            return DataLayer.DataLayer.UpdateUser(user);
        }

        public bool UpdateProject(ProjectModel projectModel)
        {
            EntityMapper<ProjectModel, Project> mapObj = new EntityMapper<ProjectModel, Project>();
            var project = mapObj.Translate(projectModel);
            return DataLayer.DataLayer.UpdateProject(project);
        }

        public bool UpdateTask(TaskModel taskModel)
        {
            EntityMapper<TaskModel, Task> mapObj = new EntityMapper<TaskModel, Task>();
            var task = mapObj.Translate(taskModel);
            return DataLayer.DataLayer.UpdateTask(task);
        }

        public bool UpdateParentTask(ParentTaskModel parentTaskModel)
        {
            EntityMapper<ParentTaskModel, ParentTask> mapObj = new EntityMapper<ParentTaskModel, ParentTask>();
            var parentTask = mapObj.Translate(parentTaskModel);
            return DataLayer.DataLayer.UpdateParentTask(parentTask);
        }

        public List<UserModel> SearchUsers(string searchKeyWord, string sortBy)
        {
            EntityMapper<User, UserModel> mapObj = new EntityMapper<User, UserModel>();
            List<User> userList = DataLayer.DataLayer.SearchUsers(searchKeyWord, sortBy);
            List<UserModel> userModels = new List<UserModel>();
            foreach (var user in userList)
            {
                userModels.Add(mapObj.Translate(user));
            }

            return userModels;
        }

        public List<ProjectModel> SearchProjects(string searchKeyWord, string sortBy)
        {
            EntityMapper<Project, ProjectModel> mapObj = new EntityMapper<Project, ProjectModel>();
            List<Project> projectList = DataLayer.DataLayer.SearchProjects(searchKeyWord, sortBy);
            List<ProjectModel> projectModels = new List<ProjectModel>();
            foreach (var project in projectList)
            {
                projectModels.Add(mapObj.Translate(project));
            }

            return projectModels;
        }

        public bool DeleteProject(int projectID)
        {
            return DataLayer.DataLayer.DeleteProject(projectID);
        }

        public bool DeleteUser(int userID)
        {
            return DataLayer.DataLayer.DeleteUser(userID);
        }        
    }
}
