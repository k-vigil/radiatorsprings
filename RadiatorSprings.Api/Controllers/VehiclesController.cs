using RadiatorSprings.Application.Vehicles.AddVehicle;
using RadiatorSprings.Application.Vehicles.GetVehicleById;
using RadiatorSprings.Application.Vehicles.GetVehicles;
using RadiatorSprings.Application.Vehicles.UpdateVehicle;

namespace RadiatorSprings.Api.Controllers;

[Authorize]
[Route("api/vehicles")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly ISender _mediator;

    public VehiclesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [PermissionRequired("view_vehicles")]
    [HttpGet]
    public async Task<IActionResult> GetVehicles() =>
        Ok((await _mediator.Send(new GetVehiclesQuery())));

    [PermissionRequired("view_single_vehicle")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetVehicle(int id) =>
       Ok((await _mediator.Send(new GetVehicleByIdQuery(id))));

    [PermissionRequired("add_vehicle")]
    [HttpPost]
    public async Task<IActionResult> AddVehicle([FromBody] AddVehicleCommand command) =>
       Created("", (await _mediator.Send(command)));

    [PermissionRequired("update_vehicle")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateVehicle(int id, [FromBody] UpdateVehicleCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}
