using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain
{
    public class KeyGeneratorStrategy : IKeyGeneratorStrategy
    {
        private readonly IEmployeeKeyGenerator _employeeKeyGenerator;

        public KeyGeneratorStrategy(IEmployeeKeyGenerator employeeKeyGnerator)
        {
            _employeeKeyGenerator = employeeKeyGnerator;
        }

        public IKeyGenerator<TKeyType> GetKeyGenerator<TKeyType>()
        {
            //TODO: dictionary <KeyType, KeyTypeGenerator>

            if(typeof(TKeyType) == typeof(RegistrationNumber))
            {
                return (IKeyGenerator<TKeyType>)_employeeKeyGenerator;
            }

            throw new InvalidOperationException();
        }
    }
}
