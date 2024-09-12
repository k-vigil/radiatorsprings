namespace RadiatorSprings.Application.Bookings.GetBookingById;

public record GetBookingByIdQuery(int Id) : IRequest<object>;
