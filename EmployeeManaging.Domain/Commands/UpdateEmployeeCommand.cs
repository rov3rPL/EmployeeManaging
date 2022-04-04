using System.Runtime.Serialization;
using MediatR;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public EmployeeId EmployeeId { get; }

        public Surname NewName { get; }

        public Gender Gender { get; }

        public UpdateEmployeeCommand(EmployeeId employeeId, Surname newName, Gender gender)
        {
            EmployeeId = employeeId;
            NewName = newName;
            Gender = gender;
        }
    }
}
