using RadiatorSprings.Application.Customers.AddCustomer;
using RadiatorSprings.Application.Customers.GetCustomerById;
using RadiatorSprings.Application.Customers.GetCustomers;
using RadiatorSprings.Application.Customers.UpdateCustomer;

namespace RadiatorSprings.Api.Controllers;

[Authorize]
[Route("api/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ISender _mediator;

    public CustomersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [PermissionRequired("view_customers")]
    [HttpGet]
    public async Task<IActionResult> GetCustomers() =>
        Ok((await _mediator.Send(new GetCustomersQuery())));

    [PermissionRequired("view_single_customer")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCustomer(int id) =>
       Ok((await _mediator.Send(new GetCustomerByIdQuery(id))));

    [PermissionRequired("add_customer")]
    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerCommand command) =>
       Created("", (await _mediator.Send(command)));

    [PermissionRequired("update_customer")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}
