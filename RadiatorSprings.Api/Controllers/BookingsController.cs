using RadiatorSprings.Application.Bookings.AddBooking;
using RadiatorSprings.Application.Bookings.GetBookingById;
using RadiatorSprings.Application.Bookings.GetBookings;

namespace RadiatorSprings.Api.Controllers;

[Authorize]
[Route("api/bookings")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly ISender _mediator;

    public BookingsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [PermissionRequired("view_bookings")]
    [HttpGet]
    public async Task<IActionResult> GetBookings() =>
        Ok((await _mediator.Send(new GetBookingsQuery())));

    [PermissionRequired("view_single_booking")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBooking(int id) =>
        Ok((await _mediator.Send(new GetBookingByIdQuery(id))));

    [PermissionRequired("add_booking")]
    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] AddBookingCommand command) =>
        Created("", (await _mediator.Send(command)));
}
