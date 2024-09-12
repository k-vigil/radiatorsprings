namespace RadiatorSprings.Application.Bookings.AddBooking;

public sealed class AddBookingCommandHandler : IRequestHandler<AddBookingCommand, object>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddBookingCommandHandler(IBookingRepository bookingRepository, IVehicleRepository vehicleRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _vehicleRepository = vehicleRepository;
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<object> Handle(AddBookingCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId);

        if (vehicle is null) throw new Exception("Vehiculo no existente");

        if (!vehicle.Active) throw new Exception("Vehiculo no disponible");

        var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);

        if (customer is null) throw new Exception("Cliente no existente");

        if (request.Departure > request.Return) throw new Exception("Las fechas no coinciden");

        var booking = new Booking(
            1,
            request.VehicleId,
            request.CustomerId,
            request.Departure,
            request.Return);

        var total = booking.CalculateTotal(vehicle.Price);
        booking.Total = total;

        _bookingRepository.AddBooking(booking);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return booking.Id;
    }
}
