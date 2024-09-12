using RadiatorSprings.Application.Permissions.GetPermissions;

namespace RadiatorSprings.Api.Controllers;

[Authorize]
[Route("api/permissions")]
[ApiController]
public class PermissionsController : ControllerBase
{
    private readonly ISender _mediator;

    public PermissionsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [PermissionRequired("view_permissions")]
    [HttpGet]
    public async Task<IActionResult> GetPermissions() =>
        Ok((await _mediator.Send(new GetPermissionsQuery())));
}
