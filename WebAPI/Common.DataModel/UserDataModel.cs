using System;
using System.Runtime.Serialization;

namespace Common.DataModel
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "userID")]
        public int User_ID { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "employeeID")]
        public int Employee_ID { get; set; }

        [DataMember(Name = "projectID")]
        public Nullable<int> Project_ID { get; set; }

        [DataMember(Name = "taskID")]
        public Nullable<int> Task_ID { get; set; }
    }
}
