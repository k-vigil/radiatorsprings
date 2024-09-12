namespace RadiatorSprings.Application.Vehicles.GetVehicleById;

public sealed class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, object>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<object> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _vehicleRepository.GetVehicleByIdAsync(request.Id);

        if (data is null) return Task.CompletedTask;

        var dto = new VehicleDto(
            data.Id,
            data.Description,
            data.UrlImage,
            data.Price,
            data.Active,
            data.Category.Name);

        return dto;
    }
}
