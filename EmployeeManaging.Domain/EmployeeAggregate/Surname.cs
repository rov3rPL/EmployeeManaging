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

            value = value.Trim();
            if (value.Length > 50)
                throw new ArgumentOutOfRangeException("value", $"{typeof(Surname).Name} cannot be initialized with '{value}'");

            //[DONE] TODO cr w takich przypadkach warto zabezpieczyć się też na spacje na początku i końcu stringa.

            Value = value;
        }
    }
}