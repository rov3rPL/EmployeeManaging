using Microsoft.AspNetCore.Mvc;
using MediatR;
using EmployeeManaging.Domain.Commands;
using EmployeeManaging.Api.Application.Models;
using EmployeeManaging.Domain.EmployeeAggregate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManaging.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeesController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeData employee)
        {
            var employeeName = new Surname(employee.EmployeeName);
            var gender = Gender.From(employee.GenderId);
            var command = new CreateEmployeeCommand(employeeName, gender);

            var commandResult = await mediator.Send(command);

            return Ok(commandResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeData employee)
        {
            var employeeId = new EmployeeId(id);
            var employeeName = new Surname(employee.EmployeeName);
            var gender = Gender.From(employee.GenderId);
            var command = new UpdateEmployeeCommand(employeeId, employeeName, gender);

            var commandResult = await mediator.Send(command);

            return Ok(commandResult);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
