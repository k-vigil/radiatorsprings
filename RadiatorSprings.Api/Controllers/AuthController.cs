using RadiatorSprings.Application.Auth;

namespace RadiatorSprings.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Signin([FromBody] SignInCommand command) =>
        Ok((await _mediator.Send(command)));
}
