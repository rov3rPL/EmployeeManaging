using System.Runtime.Serialization;

namespace EmployeeManaging.Api.Application.Models
{
    [DataContract]

    public class EmployeeData
    {
        [DataMember]
        public string EmployeeName { get; private set; }

        [DataMember]
        public int GenderId { get; private set; }

        public EmployeeData(string employeeName, int genderId)
        {
            EmployeeName = employeeName;
            GenderId = genderId;
        }
    }
}
