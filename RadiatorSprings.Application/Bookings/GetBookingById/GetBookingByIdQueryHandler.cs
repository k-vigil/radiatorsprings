namespace RadiatorSprings.Application.Bookings.GetBookingById;

public sealed class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, object>
{
    private readonly IBookingRepository _bookingRepository;

    public GetBookingByIdQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<object> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _bookingRepository.GetBookingByIdAsync(request.Id);

        if (data is null) return Task.CompletedTask;

        var dto = new BookingDto(
            data.Id,
            data.Departure.ToShortDateString(),
            data.Return.ToShortDateString(),
            data.Customer.FirstName,
            data.Vehicle.Description);

        return dto;
    }
}
