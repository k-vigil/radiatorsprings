using RadiatorSprings.Core.Entities;

namespace RadiatorSprings.Core.Interfaces;

public interface IVehicleRepository
{
    Task<IReadOnlyList<Vehicle>> GetVehiclesAsync();
    Task<Vehicle?> GetVehicleByIdAsync(int id);
    void AddVehicle(Vehicle vehicle);
    void UpdateVehicle(Vehicle vehicle);
}
