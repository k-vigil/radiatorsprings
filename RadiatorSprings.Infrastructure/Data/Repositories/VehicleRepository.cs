namespace RadiatorSprings.Infrastructure.Data.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddVehicle(Vehicle vehicle) =>
        _context.Vehicles.Add(vehicle);

    public async Task<Vehicle?> GetVehicleByIdAsync(int id) =>
        await _context.Vehicles
            .Include(v => v.Category)
            .SingleOrDefaultAsync(v => v.Id == id);

    public async Task<IReadOnlyList<Vehicle>> GetVehiclesAsync() =>
        await _context.Vehicles
            .AsNoTracking()
            .Include(v => v.Category)
            .ToListAsync();

    public void UpdateVehicle(Vehicle vehicle) =>
        _context.Vehicles.Update(vehicle);
}
