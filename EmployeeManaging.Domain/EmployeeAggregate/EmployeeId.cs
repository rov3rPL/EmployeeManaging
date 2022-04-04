using EmployeeManaging.Domain.SeedWork;

namespace EmployeeManaging.Domain.EmployeeAggregate
{
    public class EmployeeId : ValueObject
    {
        public int Value { get; }

        public EmployeeId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be positive number.");

            Value = id;
        }
    }
}
