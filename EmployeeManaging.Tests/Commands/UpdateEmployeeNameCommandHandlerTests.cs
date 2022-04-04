using Xunit;
using Moq;
using EmployeeManaging.Domain.EmployeeAggregate;
using EmployeeManaging.Domain.Commands;

namespace EmployeeManaging.Tests.Domain.Commands
{
    public class UpdateEmployeeNameCommandHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;

        public UpdateEmployeeNameCommandHandlerTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
        }

        [Fact]
        public async Task RepositoryUpdateMethodIsCalled()
        {
            // Arrange
            var newEmployeeName = new Surname("new name");
            var newGender = Gender.Female;
            var fakeEmployeeCmd = new UpdateEmployeeCommand(new EmployeeId(1), newEmployeeName, newGender);

            _employeeRepositoryMock.Setup(x => x.Update(It.IsAny<Employee>()));

            var _uowMock = new Mock<EmployeeManaging.Domain.SeedWork.IUnitOfWork>();
            _uowMock.Setup(x => x.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));
            _employeeRepositoryMock.Setup(x => x.UnitOfWork)
                .Returns(_uowMock.Object);

            var employee = new Employee(new Surname("old name"), Gender.Male, new RegistrationNumber(12345678));

            _employeeRepositoryMock.Setup(x => x.GetAsync(
                It.IsAny<EmployeeId>()
                )
            )
            .Returns(Task.FromResult(employee));

            Assert.NotEqual(employee.Surname, newEmployeeName);
            Assert.NotEqual(employee.Gender, newGender);

            //Act
            var handler = new UpdateEmployeeCommandHandler(_employeeRepositoryMock.Object);
            var result = await handler.Handle(fakeEmployeeCmd, new CancellationToken());

            //Assert
            Assert.True(result);

            _employeeRepositoryMock.Verify(x => x.Update(It.IsAny<Employee>()),
                Times.Once());

            Assert.Equal(employee.Surname, newEmployeeName);
            Assert.Equal(employee.Gender, newGender);
        }
    }
}
