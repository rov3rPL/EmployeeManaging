using EmployeeManaging.Domain.SeedWork;

namespace EmployeeManaging.Domain.EmployeeAggregate
{
    public class Surname : ValueObject
    {
        public String Value { get; private set; }

        public Surname(string value)
        {
            if(null == value)
                throw new ArgumentNullException("value");
            if(String.Equals(value, String.Empty))
                throw new ArgumentException("value", $"{typeof(Surname).Name} cannot be empty");

            if (value.Length > 50)
                throw new ArgumentOutOfRangeException("value", $"{typeof(Surname).Name} cannot be initialized with '{value}'");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Value;
        }

    }
}