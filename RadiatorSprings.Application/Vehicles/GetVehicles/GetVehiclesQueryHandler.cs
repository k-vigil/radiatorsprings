namespace RadiatorSprings.Application.Vehicles.GetVehicles;

public sealed class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, object>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehiclesQueryHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<object> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var data = await _vehicleRepository.GetVehiclesAsync();
        var dto = data.Select(i => new VehicleDto(
            i.Id,
            i.Description,
            i.UrlImage,
            i.Price,
            i.Active,
            i.Category.Name));

        return dto;
    }
}
