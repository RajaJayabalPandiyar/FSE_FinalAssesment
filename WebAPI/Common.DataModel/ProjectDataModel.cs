using System;
using System.Runtime.Serialization;

namespace Common.DataModel
{
    [DataContract]
    public class ProjectModel
    {
        [DataMember(Name = "projectID")]
        public int Project_ID { get; set; }

        [DataMember(Name = "projectName")]
        public string ProjectName { get; set; }

        [DataMember(Name = "startDate")]
        public Nullable<System.DateTime> Start_Date { get; set; }

        [DataMember(Name = "endDate")]
        public Nullable<System.DateTime> End_Date { get; set; }

        [DataMember(Name = "priority")]
        public int Priority { get; set; }

        [DataMember(Name = "noOfTasks")]
        public int NoOfTasks { get; set; }

        [DataMember(Name = "completedTasks")]
        public int CompletedTasks { get; set; }
    }
}
