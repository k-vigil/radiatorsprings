namespace RadiatorSprings.Application.Vehicles.UpdateVehicle;

public sealed class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, object>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<object> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.Id);

        if (vehicle is null) return Task.CompletedTask;

        vehicle.Description = request.Description;
        vehicle.UrlImage = request.UrlImage;
        vehicle.Price = request.Price;
        vehicle.Active = request.Active;
        vehicle.CategoryId = request.CategoryId;

        _vehicleRepository.UpdateVehicle(vehicle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Task.CompletedTask;
    }
}
