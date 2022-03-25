using MediatR;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository employeeRepository;
        //private readonly IMediator mediator;
        //private readonly ILogger<CreateEmployeeCommandHandler> logger;
        private readonly IKeyGeneratorStrategy keyGeneratorStrategy;

        public CreateEmployeeCommandHandler(//IMediator mediator,
            IEmployeeRepository employeeRepository,
            //ILogger<CreateEmployeeCommandHandler> logger
            IKeyGeneratorStrategy keyGeneratorStrategy
            )
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            //this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            //this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.keyGeneratorStrategy = keyGeneratorStrategy ?? throw new ArgumentNullException(nameof(keyGeneratorStrategy));
        }

        public async Task<bool> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            // Add/Update the Employee aggregate root
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate

            var result = false;

            try
            {
                var registrationNumberGenerator = keyGeneratorStrategy.GetKeyGenerator<RegistrationNumber>();
                var registrationNumber = registrationNumberGenerator.GetNextKey();  

                var employee = new Employee(
                    new Surname(command.EmployeeName),
                    Gender.From(command.GenderId),
                    registrationNumber
                );

                //logger.LogInformation("----- Creating Employee - Employee: {@Employee}", employee);

                employeeRepository.Add(employee);

                result = await employeeRepository.UnitOfWork
                    .SaveEntitiesAsync(cancellationToken);
            }
            catch (Exception ex) { //TODO: exception filtering and converting to business exceptions
                throw ex;
            }
            finally
            {
            }

            return result;
        }

    }
}
