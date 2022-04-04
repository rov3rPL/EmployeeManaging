using MediatR;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IRegistrationNumberProvider registrationNumberProvider;

        public CreateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            IRegistrationNumberProvider registrationNumberProvider
            )
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            this.registrationNumberProvider = registrationNumberProvider ?? throw new ArgumentNullException(nameof(registrationNumberProvider));
        }

        public async Task<bool> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var result = false;

            var registrationNumber = registrationNumberProvider.GetNextRegistrationNumber();  

            var employee = new Employee(command.EmployeeName, command.Gender, registrationNumber);

            employeeRepository.Add(employee);

            result = await employeeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
            
            return result;
        }

    }
}
