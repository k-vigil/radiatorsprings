namespace RadiatorSprings.Application.Bookings.AddBooking;

public record AddBookingCommand(
    int CustomerId,
    int VehicleId,
    DateTime Departure,
    DateTime Return) : IRequest<object>;
