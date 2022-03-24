using Xunit;
using EmployeeManaging.Domain.EmployeeAggregate;

namespace EmployeeManaging.Tests.Domain
{
    public class SurnameTests
    {
        [Fact]
        public void ExceptionWhenInitializedWithNullValue()
        {
            String nullName = null;

            var ex = Assert.Throws<ArgumentNullException>(() => new Surname(nullName));
        }

        [Fact]
        public void ExceptionWhenInitializedWithEmptyValue()
        {
            String emptyName = "";

            var ex = Assert.Throws<ArgumentException>(() => new Surname(emptyName));
        }

        [Fact]
        public void ExceptionWhenInitializedWithTooLongString()
        {
            var tooLongName = new String('a', 51);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Surname(tooLongName));
        }
    }
}
