using RadiatorSprings.Application.Users.AddUser;
using RadiatorSprings.Application.Users.GetUserById;
using RadiatorSprings.Application.Users.GetUsers;

namespace RadiatorSprings.Api.Controllers;

[Authorize]
[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ISender _mediator;

    public UsersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [PermissionRequired("view_users")]
    [HttpGet]
    public async Task<IActionResult> GetUsers() =>
        Ok((await _mediator.Send(new GetUsersQuery())));

    [PermissionRequired("view_single_user")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id) =>
        Ok((await _mediator.Send(new GetUserByIdQuery(id))));

    [PermissionRequired("add_user")]
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserCommand command) =>
        Created("", (await _mediator.Send(command)));
}
