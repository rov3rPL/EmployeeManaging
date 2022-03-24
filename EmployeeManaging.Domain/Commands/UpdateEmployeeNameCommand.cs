using System.Runtime.Serialization;
using MediatR;

namespace EmployeeManaging.Domain.Commands
{
    [DataContract]
    public class UpdateEmployeeNameCommand : IRequest<bool>
    {
        [DataMember]
        public int EmployeeId { get; private set; }

        [DataMember]
        public string NewName { get; private set; }

        [DataMember]
        public int GenderId { get; private set; }

        public UpdateEmployeeNameCommand(int employeeId, string newName, int genderId)
        {
            EmployeeId = employeeId;
            NewName = newName;
            GenderId = genderId;
        }
    }
}
