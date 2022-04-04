using System.Runtime.Serialization;
using EmployeeManaging.Domain.EmployeeAggregate;
using MediatR;

namespace EmployeeManaging.Domain.Commands
{
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public Surname EmployeeName { get; }
        public Gender Gender { get; }

        public CreateEmployeeCommand(Surname employeeName, Gender gender)
        {
            EmployeeName = employeeName;
            Gender = gender;
        }
    }
}
