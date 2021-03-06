using Xunit;
using Moq;
using MediatR;
using EmployeeManaging.Domain.Commands;
using EmployeeManaging.Domain.EmployeeAggregate;
using EmployeeManaging.Domain;

namespace EmployeeManaging.Tests.Domain.Commands
{
    public class CreateEmployeeCommandHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;

        public CreateEmployeeCommandHandlerTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
        }

        [Fact]
        public async Task RepositoryAddMethodIsCalled()
        {
            // Arrange
            var fakeEmployeeCmd = new CreateEmployeeCommand("testName", 1);

            _employeeRepositoryMock.Setup(x => x.Add(It.IsAny<Employee>()))
                .Returns(It.IsAny<Employee>);
            
            var _uowMock = new Mock<EmployeeManaging.Domain.SeedWork.IUnitOfWork>();
            _uowMock.Setup(x => x.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));
            _employeeRepositoryMock.Setup(x => x.UnitOfWork)
                .Returns(_uowMock.Object);

            var _employeeKeyGeneratorMock = new Mock<IEmployeeKeyGenerator>();
            _employeeKeyGeneratorMock.Setup(x => x.GetNextKey())
                .Returns(new RegistrationNumber("12345678"));
            var _keyGeneratorStrategyMock = new Mock<IKeyGeneratorStrategy>();
            _keyGeneratorStrategyMock.Setup(x => x.GetKeyGenerator<RegistrationNumber>())
                .Returns(_employeeKeyGeneratorMock.Object);

            //Act
            var handler = new CreateEmployeeCommandHandler(_employeeRepositoryMock.Object, _keyGeneratorStrategyMock.Object);
            var result = await handler.Handle(fakeEmployeeCmd, new CancellationToken());

            //Assert
            Assert.True(result);
            _employeeRepositoryMock.Verify(x => x.Add(It.IsAny<Employee>()),
                Times.Once());
        }


    }
}
