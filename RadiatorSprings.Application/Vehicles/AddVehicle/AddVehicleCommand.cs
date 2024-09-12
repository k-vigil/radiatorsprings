namespace RadiatorSprings.Application.Vehicles.AddVehicle;

public record AddVehicleCommand(
    string Description,
    string UrlImage,
    decimal Price,
    int CategoryId) : IRequest<object>;
