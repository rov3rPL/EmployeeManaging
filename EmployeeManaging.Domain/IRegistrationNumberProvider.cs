using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain
{
    public interface IRegistrationNumberProvider
    {
        RegistrationNumber GetNextRegistrationNumber();
    }
}
