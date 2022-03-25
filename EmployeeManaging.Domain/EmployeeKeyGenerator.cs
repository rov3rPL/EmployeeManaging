using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Domain
{
    //Hi/Lo Algorithm
    public class EmployeeKeyGenerator : IEmployeeKeyGenerator
    {
        private static readonly object _lock = new object(); // for handling multiple calls at the same time
        private int _currentHi;
        private readonly int _maxLo = 20; //arbitrary set the size of pool
        private int _currentLo = int.MaxValue;  // starts with the maximum value to ensure the repository's first call

        private readonly IEmployeeHiLoRepository repository;

        public EmployeeKeyGenerator(IEmployeeHiLoRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        public RegistrationNumber GetNextKey()
        {
            return new RegistrationNumber(getKey());
        }

        private int getKey()
        {
            lock (_lock)
            {
                if (_currentLo >= _maxLo)
                {
                    _currentHi = repository.GetNextHi();
                    _currentLo = 0;
                }
                int result = _currentHi * _maxLo + _currentLo;
                _currentLo++;
                return result;
            }
        }
    }
}
