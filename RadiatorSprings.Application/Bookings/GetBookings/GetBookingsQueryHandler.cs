namespace RadiatorSprings.Application.Bookings.GetBookings;

public sealed class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, object>
{
    private readonly IBookingRepository _bookingRepository;

    public GetBookingsQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<object> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
    {
        var data = await _bookingRepository.GetBookingsAsync();
        var dto = data.Select(i => new BookingDto(
            i.Id,
            i.Departure.ToShortDateString(),
            i.Return.ToShortDateString(),
            i.Customer.FirstName,
            i.Vehicle.Description));

        return dto;
    }
}
