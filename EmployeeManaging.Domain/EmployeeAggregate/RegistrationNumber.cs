using EmployeeManaging.Domain.SeedWork;

namespace EmployeeManaging.Domain.EmployeeAggregate
{
    public class RegistrationNumber : ValueObject
    {
        public String Value { get; } //[DONE] todo cr private set niepotrzebny, nigdy się nie zmienia

        //[DONE, ten konstruktor był używany tylko przez testy, całkowicie niepotrzebny w rozwiązaniu]
        //public RegistrationNumber(string value)
        //{
        //    if(null == value)
        //        throw new ArgumentNullException("value");
        //    if(value.Length != 8)
        //        throw new ArgumentOutOfRangeException("value", $"{typeof(RegistrationNumber).Name} in incorrect format");
        //    //TODO cr Co jeśli podam nie tylko cyfry? Zostanie to błędnie zaakceptowane.

        //    Value = value;
        //}

        public RegistrationNumber(int value)
        {
            var valueStr = value.ToString("00000000");
            if (valueStr.Length != 8)
                throw new ArgumentOutOfRangeException("value", $"{typeof(RegistrationNumber).Name} exceeded capacity!"); 

            Value = valueStr;
        }
    }
}