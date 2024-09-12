namespace RadiatorSprings.Application.Vehicles.AddVehicle;

public sealed class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, object>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddVehicleCommandHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<object> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle(
            request.Description,
            request.UrlImage,
            request.Price,
            request.CategoryId);

        _vehicleRepository.AddVehicle(vehicle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return vehicle.Id;
    }
}
