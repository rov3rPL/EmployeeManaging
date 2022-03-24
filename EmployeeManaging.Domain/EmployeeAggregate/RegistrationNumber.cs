using EmployeeManaging.Domain.SeedWork;

namespace EmployeeManaging.Domain.EmployeeAggregate
{
    public class RegistrationNumber : ValueObject
    {
        public String Value { get; private set; }

        public RegistrationNumber(string value)
        {
            if(null == value)
                throw new ArgumentNullException("value");
            if(value.Length != 8)
                throw new ArgumentOutOfRangeException("value", $"{typeof(RegistrationNumber).Name} in incorrect format");

            Value = value;
        }

        public RegistrationNumber(int value)
        {
            var valueStr = value.ToString("00000000");
            if (valueStr.Length != 8)
                throw new ArgumentOutOfRangeException("value", $"{typeof(RegistrationNumber).Name} exceeded capacity!");

            Value = valueStr;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Value;
        }

    }
}