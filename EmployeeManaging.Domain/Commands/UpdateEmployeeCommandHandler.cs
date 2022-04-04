using MediatR;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<bool> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await employeeRepository.GetAsync(command.EmployeeId);

            employee.Update(command.NewName, command.Gender);

            employeeRepository.Update(employee);

            return await employeeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
