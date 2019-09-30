using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public static class DataLayer
    {
        static ProjectManagerEntities DbContext;

        static DataLayer()
        {
            DbContext = new ProjectManagerEntities();
        }

        public static List<Task> GetTasks()
        {
            return DbContext.Tasks.ToList();
        }
        public static List<Project> GetProjects()
        {
            return DbContext.Projects.ToList();
        }
        public static List<User> GetUsers()
        {
            return DbContext.Users.ToList();
        }
        public static List<ParentTask> GetParentTasks()
        {
            return DbContext.ParentTasks.ToList();
        }
        //------------------------------------------

        public static Task GetTask(int taskID)
        {
            return DbContext.Tasks.Where(x => x.Task_ID == taskID).FirstOrDefault();
        }
        public static Project GetProject(int projectID)
        {
            return DbContext.Projects.Where(x => x.Project_ID == projectID).FirstOrDefault();
        }
        public static User GetUser(int userID)
        {
            return DbContext.Users.Where(x => x.User_ID == userID).FirstOrDefault();
        }
        public static ParentTask GetParentTask(int parentTaskID)
        {
            return DbContext.ParentTasks.Where(x => x.Parent_ID == parentTaskID).FirstOrDefault();
        }
        //------------------------------------------


        public static bool InsertTask(Task task)
        {
            bool status;
            try
            {
                DbContext.Tasks.Add(task);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static bool InsertProject(Project project)
        {
            bool status;
            try
            {
                DbContext.Projects.Add(project);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static bool InsertUser(User user)
        {
            bool status;
            try
            {
                DbContext.Users.Add(user);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static bool InsertParentTask(ParentTask parentTask)
        {
            bool status;
            try
            {
                DbContext.ParentTasks.Add(parentTask);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        //------------------------------------------

        public static bool UpdateTask(Task task)
        {
            bool status;
            try
            {
                Task taskItem = DbContext.Tasks.Where(x => x.Task_ID == task.Task_ID).FirstOrDefault();
                if (taskItem != null)
                {
                    taskItem.Parent_ID = task.Parent_ID;
                    taskItem.Project_ID = task.Project_ID;
                    taskItem.TaskName = task.TaskName;
                    taskItem.Start_Date = task.Start_Date;
                    taskItem.End_Date = task.End_Date;
                    taskItem.Priority = task.Priority;
                    taskItem.Status = task.Status;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateProject(Project project)
        {
            bool status;
            try
            {
                Project ProjectItem = DbContext.Projects.Where(x => x.Project_ID == project.Project_ID).FirstOrDefault();
                if (ProjectItem != null)
                {
                    ProjectItem.ProjectName = project.ProjectName;
                    ProjectItem.Start_Date = project.Start_Date;
                    ProjectItem.End_Date = project.End_Date;
                    ProjectItem.Priority = project.Priority;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateUser(User user)
        {
            bool status;
            try
            {
                User UserItem = DbContext.Users.Where(x => x.User_ID == user.User_ID).FirstOrDefault();
                if (UserItem != null)
                {
                    UserItem.FirstName = user.FirstName;
                    UserItem.LastName = user.LastName;
                    UserItem.Employee_ID = user.Employee_ID;
                    UserItem.Project_ID = user.Project_ID;
                    UserItem.Task_ID = user.Task_ID;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateParentTask(ParentTask parentTask)
        {
            bool status;
            try
            {
                ParentTask ParentTaskItem = DbContext.ParentTasks.Where(x => x.Parent_ID == parentTask.Parent_ID).FirstOrDefault();
                if (ParentTaskItem != null)
                {
                    ParentTaskItem.ParentTaskName = parentTask.ParentTaskName;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        //------------------------------------------
        public static bool DeleteTask(int taskID)
        {
            bool status;
            try
            {
                Task taskItem = DbContext.Tasks.Where(x => x.Task_ID == taskID).FirstOrDefault();
                if (taskItem != null)
                {
                    DbContext.Tasks.Remove(taskItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteProject(int projectID)
        {
            bool status;
            try
            {
                var tasks = DbContext.Tasks.Where(x => x.Project_ID == projectID).ToList();
                if (tasks != null && tasks.Count > 0)
                {
                    foreach (var task in tasks)
                    {
                        if (task != null)
                        {
                            DbContext.Tasks.Remove(task);
                            DbContext.SaveChanges();
                        }
                    }
                }

                Project projectItem = DbContext.Projects.Where(x => x.Project_ID == projectID).FirstOrDefault();
                if (projectItem != null)
                {
                    DbContext.Projects.Remove(projectItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteUser(int userID)
        {
            bool status;
            try
            {
                User UserItem = DbContext.Users.Where(x => x.User_ID == userID).FirstOrDefault();
                if (UserItem != null)
                {
                    DbContext.Users.Remove(UserItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteParentTask(int parentID)
        {
            bool status;
            try
            {
                ParentTask ParentTaskItem = DbContext.ParentTasks.Where(x => x.Parent_ID == parentID).FirstOrDefault();
                if (ParentTaskItem != null)
                {
                    DbContext.ParentTasks.Remove(ParentTaskItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        //------------------------------------------

        public static List<Project> SearchProjects(string searchKeyWord, string sortBy)
        {
            return DbContext.Projects.Where(x => x.Start_Date.ToString().Contains(searchKeyWord) || x.End_Date.ToString().Contains(searchKeyWord) || x.Priority.ToString().Contains(searchKeyWord)).ToList().OrderBy(x => sortBy).ToList();
        }
        public static List<User> SearchUsers(string searchKeyWord, string sortBy)
        {
            return DbContext.Users.Where(x => x.FirstName.Contains(searchKeyWord) || x.LastName.Contains(searchKeyWord) || x.Employee_ID.ToString().Contains(searchKeyWord)).ToList().OrderBy(x => sortBy).ToList();
        }
    }
}
