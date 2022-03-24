using Xunit;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Tests.Domain
{
    public class EmployeeTests
    {
        [Fact]
        public void ExceptionWhenInitializedWithNullName()
        {
            Surname nullName = null;

            var ex = Assert.Throws<ArgumentNullException>(() => new Employee(nullName, Gender.Female, new RegistrationNumber("12345678")));
        }

        [Fact]
        public void UpdatingEmployeeName()
        {
            var employee = new Employee(new Surname("old"), Gender.Male, new RegistrationNumber("12345678"));

            var newName = new Surname("new");
            var newGender = Gender.Female;

            Assert.NotEqual(employee.Surname.Value, newName.Value);
            Assert.NotEqual(employee.Gender, newGender);
            
            employee.Update(newName, newGender);

            Assert.Equal(employee.Surname.Value, newName.Value);
            Assert.Equal(employee.Gender, newGender);
        }
    }
}
