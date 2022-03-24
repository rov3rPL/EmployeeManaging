using System.Runtime.Serialization;
using MediatR;

namespace EmployeeManaging.Domain.Commands
{
    [DataContract]

    public class CreateEmployeeCommand : IRequest<bool>
    {
        [DataMember]
        public string EmployeeName { get; private set; }

        [DataMember]
        public int GenderId { get; private set; }

        public CreateEmployeeCommand(string name, int genderId)
        {
            EmployeeName = name;
            GenderId = genderId;
        }
    }
}
