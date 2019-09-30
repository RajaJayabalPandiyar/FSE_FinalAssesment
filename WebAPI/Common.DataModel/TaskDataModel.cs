using System;
using System.Runtime.Serialization;

namespace Common.DataModel
{
    [DataContract]
    public class TaskModel
    {
        [DataMember(Name = "taskID")]
        public int Task_ID { get; set; }

        [DataMember(Name = "taskName")]
        public string TaskName { get; set; }

        [DataMember(Name = "parentID")]
        public int Parent_ID { get; set; }

        [DataMember(Name = "parentTaskName")]
        public string ParentTaskName { get; set; }

        [DataMember(Name = "projectID")]
        public int Project_ID { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime Start_Date { get; set; }

        [DataMember(Name = "endDate")]
        public DateTime End_Date { get; set; }

        [DataMember(Name = "priority")]
        public int Priority { get; set; }

        [DataMember(Name = "status")]
        public bool Status { get; set; }

        [DataMember(Name = "setasparent")]
        public bool SetAsParent { get; set; }
    }
}
