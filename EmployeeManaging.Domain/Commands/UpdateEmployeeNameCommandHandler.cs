using MediatR;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain.Commands
{
    public class UpdateEmployeeNameCommandHandler : IRequestHandler<UpdateEmployeeNameCommand, bool>
    {
        private readonly IEmployeeRepository employeeRepository;

        public UpdateEmployeeNameCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<bool> Handle(UpdateEmployeeNameCommand command, CancellationToken cancellationToken)
        {
            // Add/Update the Employee aggregate root
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate

            var employee = await employeeRepository.GetAsync(command.EmployeeId);

            var newName = new Surname(command.NewName);
            var newGender = Gender.From(command.GenderId);
            employee.Update(newName, newGender);

            employeeRepository.Update(employee);

            return await employeeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
