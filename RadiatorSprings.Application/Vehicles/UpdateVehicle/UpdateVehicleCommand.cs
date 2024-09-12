namespace RadiatorSprings.Application.Vehicles.UpdateVehicle;

public record UpdateVehicleCommand(
    int Id,
    string Description,
    string UrlImage,
    decimal Price,
    bool Active,
    int CategoryId) : IRequest<object>;
