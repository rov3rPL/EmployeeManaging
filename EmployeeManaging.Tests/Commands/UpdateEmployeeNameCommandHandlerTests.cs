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
        public async Task EmployeeUpdateMethodIsCalled()
        {
            // Arrange
            var fakeEmployeeCmd = new UpdateEmployeeNameCommand(1, "testName", 2);

            _employeeRepositoryMock.Setup(x => x.Update(It.IsAny<Employee>()))
                ; //.Returns(It.IsAny<Employee>);

            var _uowMock = new Mock<EmployeeManaging.Domain.SeedWork.IUnitOfWork>();
            _uowMock.Setup(x => x.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));
            _employeeRepositoryMock.Setup(x => x.UnitOfWork)
                .Returns(_uowMock.Object);

            var _employeeMock = new Mock<Employee>();
            _employeeMock.Setup(x => x.Update(It.IsAny<Surname>(), It.IsAny<Gender>()))
                ;

            _employeeRepositoryMock.Setup(x => x.GetAsync(
                It.IsAny<int>()
                )
            )
            .Returns(Task.FromResult(_employeeMock.Object));

            //Act
            var handler = new UpdateEmployeeNameCommandHandler(_employeeRepositoryMock.Object);
            var result = await handler.Handle(fakeEmployeeCmd, new CancellationToken());

            //Assert
            Assert.True(result);
            
            _employeeMock.Verify(x => x.Update(It.IsAny<Surname>(), It.IsAny<Gender>()),
                Times.Once());

            //TODO: check czy zmienił nazwę

        }

        [Fact]
        public async Task RepositoryUpdateMethodIsCalled()
        {
            // Arrange
            var fakeEmployeeCmd = new UpdateEmployeeNameCommand(1, "testName", 2);

            _employeeRepositoryMock.Setup(x => x.Update(It.IsAny<Employee>()))
                ; //.Returns(It.IsAny<Employee>);

            var _uowMock = new Mock<EmployeeManaging.Domain.SeedWork.IUnitOfWork>();
            _uowMock.Setup(x => x.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));
            _employeeRepositoryMock.Setup(x => x.UnitOfWork)
                .Returns(_uowMock.Object);

            var _employeeMock = new Mock<Employee>();
            //_employeeMock.Setup ...

            _employeeRepositoryMock.Setup(x => x.GetAsync(
                It.IsAny<int>()
                )
            )
            .Returns(Task.FromResult(_employeeMock.Object));

            //Act
            var handler = new UpdateEmployeeNameCommandHandler(_employeeRepositoryMock.Object);
            var result = await handler.Handle(fakeEmployeeCmd, new CancellationToken());

            //Assert
            Assert.True(result);

            _employeeRepositoryMock.Verify(x => x.Update(It.IsAny<Employee>()),
                Times.Once());

            //TODO: check czy zmienił nazwę
        }
    }
}
