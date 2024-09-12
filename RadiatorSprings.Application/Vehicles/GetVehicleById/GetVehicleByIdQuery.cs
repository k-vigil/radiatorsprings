namespace RadiatorSprings.Application.Vehicles.GetVehicleById;

public record GetVehicleByIdQuery(int Id) : IRequest<object>;
