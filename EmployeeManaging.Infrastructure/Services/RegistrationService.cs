using EmployeeManaging.Domain.EmployeeAggregate;
using EmployeeManaging.Domain.Services;

namespace EmployeeManaging.Infrastructure.Services
{
    public class RegistrationService : IRegistrationService
    {
        private static int number;
        public RegistrationService()
        {
            number = initWithCurrentValue();
        }
        public RegistrationNumber GetCurrentRegistrationNumberAndLock()
        {
            Monitor.Enter(this);
            return new RegistrationNumber(number);
        }

        public void IncrementRegistrationNumberAndUnlock()
        {
            ++number;
            Monitor.Exit(this);
        }

        private int initWithCurrentValue()
        {
            //TODO: in case of use load balancers current sequence number must be strored in external data source
            return 0;
        }
    }
}
