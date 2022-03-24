using Microsoft.AspNetCore.Mvc;
using MediatR;
using EmployeeManaging.Domain.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManaging.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;
        //private readonly IOrderQueries _orderQueries;
        //private readonly IIdentityService _identityService;
        //private readonly ILogger<OrdersController> _logger;

        //public OrdersController(
        //    IMediator mediator,
        //    IOrderQueries orderQueries,
        //    IIdentityService identityService,
        //    ILogger<OrdersController> logger)
        //{
        //    _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        //    _orderQueries = orderQueries ?? throw new ArgumentNullException(nameof(orderQueries));
        //    _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //}

        public EmployeesController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //[Route("draft")]
        //[HttpPost]
        //public async Task<ActionResult<OrderDraftDTO>> CreateOrderDraftFromBasketDataAsync([FromBody] CreateOrderDraftCommand createOrderDraftCommand)
        //{
        //    _logger.LogInformation(
        //        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
        //        createOrderDraftCommand.GetGenericTypeName(),
        //        nameof(createOrderDraftCommand.BuyerId),
        //        createOrderDraftCommand.BuyerId,
        //        createOrderDraftCommand);

        //    return await _mediator.Send(createOrderDraftCommand);
        //}

        // GET: api/<TestController>
        [HttpGet]
        //public IEnumerable<string> Get()
        public async Task<IActionResult> Get()
        {
            var command = new CreateEmployeeCommand("test", 1);

            var commandResult = await mediator.Send(command);

            return Ok(commandResult);

            //return new string[] { "value1", "value2" };
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
