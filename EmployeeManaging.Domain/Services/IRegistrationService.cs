using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain.Services
{
    public interface IRegistrationService
    {
        RegistrationNumber GetCurrentRegistrationNumberAndLock();
        void IncrementRegistrationNumberAndUnlock();
    }
}
